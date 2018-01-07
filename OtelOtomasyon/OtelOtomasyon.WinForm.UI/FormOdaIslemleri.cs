using Ninject;
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
        protected IUnitOfWork _unitOfWork;
    


        public FormOdaIslemleri()
        {
            var container = NinjectDependencyContainer.RegisterDependency(new StandardKernel());
            _unitOfWork = container.Get<IUnitOfWork>();
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
            _unitOfWork.GetRepo<Oda>().Add(o);
            if (_unitOfWork.Commit()>0)
            {
                MessageBox.Show("Kayıt başarılı");
            }
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
            o = _unitOfWork.GetRepo<Oda>().GetById((int)dgvOdalar.CurrentRow.Cells[0].Value);
            o.OdaAd = txtOdaAd.Text;
            o.FiyatId = FiyatIDBul((int)cbOzellik.SelectedValue, (int)cbOdaTur.SelectedValue);
            o.KatId =(int) cbKat.SelectedValue;
            if (cbAktif.SelectedItem == "Boş")
            {
                o.DoluMu=false;
            }
            else if (cbAktif.SelectedItem == "Dolu")
            {
                o.DoluMu = true;
            }
            _unitOfWork.GetRepo<Oda>().Update(o);
            if (_unitOfWork.Commit() > 0)
            {
                MessageBox.Show("Güncelleme başarılı");
            }
        }

        private void dgvOdalar_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Oda o = new Oda();
            o = _unitOfWork.GetRepo<Oda>().GetById((int)dgvOdalar.CurrentRow.Cells[0].Value);
            txtOdaAd.Text=  o.OdaAd;
            int SecilenOdaTurId = _unitOfWork.GetRepo<Fiyat>().Where(x => x.Id == o.FiyatId).Select(x=>x.OdaTurId).FirstOrDefault();
            cbOdaTur.SelectedValue = SecilenOdaTurId;
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
    }
}
