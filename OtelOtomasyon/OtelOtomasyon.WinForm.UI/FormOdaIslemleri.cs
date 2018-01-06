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
            cbKat.DataSource = OzellikList.Select(x => new
            {
                x.Id
            }).ToList();
            cbKat.ValueMember = "Id";
            cbKat.DisplayMember = "Id";

            dgvOdalar.DataSource = _unitOfWork.GetRepo<Oda>().GetList();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Oda o = new Oda();
            o.OdaAd = txtOdaAd.Text;
            o.FiyatId = FiyatIDBul((int)cbOzellik.SelectedValue, (int)cbOdaTur.SelectedValue);
            o.KatId = cbKat.SelectedIndex;
            _unitOfWork.GetRepo<Oda>().Add(o);
            if (_unitOfWork.Commit()>0)
            {
                MessageBox.Show("kayıt başarılı");
            }
            
        }

        public int FiyatIDBul(int ozellikId, int odaTurId)
        {
            int FiyatID = _unitOfWork.GetRepo<Fiyat>().Where(x => x.OzellikId == ozellikId && x.OdaTurId == odaTurId).Select(x => x.Id).FirstOrDefault();

            return FiyatID;
        }
    }
}
