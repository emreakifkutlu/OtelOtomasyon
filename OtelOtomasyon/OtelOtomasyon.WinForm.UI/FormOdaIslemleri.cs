using Ninject;
using OtelOtomassyon.BLL.Services.Abstracts;
using OtelOtomasyon.DAL.Entities;
using OtelOtomasyon.Repository.Abstract;
using OtelOtomasyon.Repository.UOW.Abstract;
using OtelOtomasyon.WinForm.UI.Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelOtomasyon.WinForm.UI
{
    public partial class FormOdaIslemleri : Form
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOdaService _odaService;


        public FormOdaIslemleri()
        {
            var container = NinjectDependencyContainer.RegisterDependency(new StandardKernel());
            _unitOfWork = container.Get<IUnitOfWork>();
            _odaService = container.Get<IOdaService>();
            InitializeComponent();
        }

        private void FormOdaIslemleri_Load(object sender, EventArgs e)
        {
            var OdaTurList = _unitOfWork.GetRepo<OdaTur>().GetList();
            cbOdaTur.DataSource = OdaTurList.Select(x => new
            {
                x.Id,
                x.TurAd
            }).ToList();
            cbOdaTur.ValueMember = "Id";
            cbOdaTur.DisplayMember = "TurAd";
           

            var OzellikList = _unitOfWork.GetRepo<Ozellik>().GetList();
            cbOzellik.DataSource = OzellikList.Select(x => new
            {
                x.Id,
                x.OzellikAd
            }).ToList();
            cbOzellik.ValueMember = "Id";
            cbOzellik.DisplayMember = "OzellikAd";
          

            var KatList = _unitOfWork.GetRepo<Kat>().GetList();
            cbKat.DataSource = KatList.Select(x => new
            {
                x.Id,
                x.KatNo
            }).ToList();
            cbKat.ValueMember = "Id";
            cbKat.DisplayMember = "KatNo";
           

            dgvOdalar.DataSource = _unitOfWork.GetRepo<Oda>().GetList();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Oda o = new Oda();
            o.OdaAd = txtOdaAd.Text;
            o.FiyatId = FiyatIDBul((int)cbOzellik.SelectedValue, (int)cbOdaTur.SelectedValue);
            o.KatId =(int)cbKat.SelectedValue;
            if (cbAktif.SelectedItem.ToString() == "Boş")
            {
                o.DoluMu = false;
            }
            else if (cbAktif.SelectedItem.ToString()== "Dolu")
            {
                o.DoluMu = true;
            }

            var result = _odaService.OdaEkle(o);
            if (result.IsValid)
            {
                MessageBox.Show(result.Message);
            }
            else
            {
                MessageBox.Show(result.Errors.FirstOrDefault());
            }
            Temizle();
            dgvOdalar.DataSource = _unitOfWork.GetRepo<Oda>().GetList();
            
        }

        public int FiyatIDBul(int ozellikId, int odaTurId)
        {
            int FiyatID = _unitOfWork.GetRepo<Fiyat>().Where(x => x.OzellikId == ozellikId && x.OdaTurId == odaTurId).Select(x => x.Id).FirstOrDefault();

            return FiyatID;
        }

        private void bntGüncelle_Click(object sender, EventArgs e)
        {
            
            Oda o = new Oda();
            o.Id = _unitOfWork.GetRepo<Oda>().GetById((int)dgvOdalar.CurrentRow.Cells[0].Value).Id;
            o.OdaAd = txtOdaAd.Text;
            o.FiyatId = FiyatIDBul((int)cbOzellik.SelectedValue, (int)cbOdaTur.SelectedValue);
            o.KatId =(int) cbKat.SelectedValue;
            if (cbAktif.SelectedItem.ToString() == "Boş")
            {
                o.DoluMu=false;
            }
            else if (cbAktif.SelectedItem.ToString() == "Dolu")
            {
                o.DoluMu = true;
            }

            var result = _odaService.OdaGuncelle(o);
            if (result.IsValid)
            {
                Temizle();
                MessageBox.Show(result.Message);
               
            }
            else
            {
                MessageBox.Show(result.Errors.FirstOrDefault());
            }
          
            
            dgvOdalar.DataSource = _unitOfWork.GetRepo<Oda>().GetList();


        }

        private void dgvOdalar_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Oda o = new Oda();
            o = _unitOfWork.GetRepo<Oda>().GetById((int)dgvOdalar.CurrentRow.Cells[0].Value);
            txtOdaAd.Text=  o.OdaAd;
            int SecilenOdaTurId = _unitOfWork.GetRepo<Fiyat>().Where(x => x.Id == o.FiyatId).Select(x=>x.OdaTurId).FirstOrDefault();
            cbOdaTur.SelectedValue = SecilenOdaTurId;
            int SecilenOzellikId= _unitOfWork.GetRepo<Fiyat>().Where(x => x.Id == o.FiyatId).Select(x => x.OzellikId).FirstOrDefault();
            cbOzellik.SelectedValue = SecilenOzellikId;
            cbKat.SelectedValue = o.KatId;
         
            if (o.DoluMu == false)
            {                
                cbAktif.SelectedItem ="Boş";
            }
            else if(o.DoluMu == true)
            {
                cbAktif.SelectedItem = "Dolu";
            }
            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Oda o = new Oda();
            o = _unitOfWork.GetRepo<Oda>().GetById((int)dgvOdalar.CurrentRow.Cells[0].Value);
            _unitOfWork.GetRepo<Oda>().Delete(o.Id);

           
            if (_unitOfWork.Commit() > 0)
            {
                MessageBox.Show("Silme işlemi tamamlandı");
            }

            dgvOdalar.DataSource = _unitOfWork.GetRepo<Oda>().GetList();

            Temizle();
        }

        private void Temizle()
        {
            txtOdaAd.Clear();
            cbOdaTur.SelectedItem = null;
            cbOzellik.SelectedItem = null;
            cbKat.SelectedItem = null;
            cbAktif.SelectedItem = null;
        }
      
        private void bntYeni_Click(object sender, EventArgs e)
        {
            Temizle();
        }

   
    }
}
