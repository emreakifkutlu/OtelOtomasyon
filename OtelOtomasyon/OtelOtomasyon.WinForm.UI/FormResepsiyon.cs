using Ninject;
using OtelOtomassyon.BLL.Services.Abstracts;
using OtelOtomassyon.BLL.Services.Concretes;
using OtelOtomasyon.DAL.Entities;
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
    public partial class FormResepsiyon : Form
    {
        protected IUnitOfWork _unitOfWork;
        protected IOdaService _odaService;
        public FormResepsiyon()
        {
            var container = NinjectDependencyContainer.RegisterDependency(new StandardKernel());
            _unitOfWork = container.Get<IUnitOfWork>();
            _odaService=container.Get<IOdaService>();
            InitializeComponent();
        }

        private void FormResepsiyon_Load(object sender, EventArgs e)
        {

            lblBosOdaSayisi.Text = _odaService.BosOdaSayisiBul().ToString();
            #region Tarih ayarları
            dtpTarih.MinDate = DateTime.Today;
            dtpTarih.MaxDate = dtpTarih.MinDate.AddDays(7);
            dtpGiris.Value = DateTime.Today;
            dtpGiris.MinDate = DateTime.Today;
            dtpCikis.MinDate = dtpGiris.MinDate.AddDays(1);
            txtGiris.Text = dtpGiris.Value.ToShortDateString();
            #endregion

            //OdaTurDoldur();

            var OdaTurList = _unitOfWork.GetRepo<OdaTur>().GetList();
            cbOdaTur.DataSource = OdaTurList.Select(x => new
            {
                x.Id,
                x.TurAd
            }).ToList();
            cbOdaTur.ValueMember = "Id";
            cbOdaTur.DisplayMember = "TurAd";

            //OdaOpsiyonDoldur();

             var OzellikList = _unitOfWork.GetRepo<Ozellik>().GetList();
            cbOpsiyon.DataSource = OzellikList.Select(x => new
            {
                x.Id,
                x.OzellikAd
            }).ToList();
            cbOpsiyon.ValueMember = "Id";
            cbOpsiyon.DisplayMember = "OzellikAd";

            //KatDoldur();

            var KatList = _unitOfWork.GetRepo<Kat>().GetList();
            cbKat.DataSource = KatList.Select(x => new
            {
                x.Id,
                x.KatNo
            }).ToList();
            cbKat.ValueMember = "Id";
            cbKat.DisplayMember = "KatNo";

            //CinsiyetDoldur();

            //MedeniHalDoldur();
            //BosOdaKontrol();


        }

        private void dtpGiris_ValueChanged(object sender, EventArgs e)
        {
            dtpGiris.MaxDate = DateTime.Today.AddDays(7);
            txtGiris.Text = dtpGiris.Value.ToShortDateString();
            dtpCikis.MinDate = dtpGiris.Value.AddDays(1);
        }

        private void dtpCikis_ValueChanged(object sender, EventArgs e)
        {
            txtCikis.Text = dtpCikis.Value.ToShortDateString();
        }

        private void btn4101_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
          
            if (btn.Text == "BOŞ")
            {
                btn.Text = "DOLU";
                btn.BackColor = Color.Red;
            }

          else  if (btn.Text == "DOLU")
            {
                btn.Text = "BOŞ";
                btn.BackColor = Color.Lime;
            }
        }
    }
}
