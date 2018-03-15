using Ninject;
using OtelOtomassyon.BLL.Services.Abstracts;
using OtelOtomassyon.BLL.Services.Concretes;
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
    public partial class FormResepsiyon : Form
    {

        protected IUnitOfWork _unitOfWork;
        protected IOdaRepository _odaRepo;
        public FormResepsiyon()
        {
            var container = NinjectDependencyContainer.RegisterDependency(new StandardKernel());
            _unitOfWork = container.Get<IUnitOfWork>();
            _odaRepo = container.Get<IOdaRepository>();
            InitializeComponent();
                                   
        }

        private void FormResepsiyon_Load(object sender, EventArgs e)
        {

           
            #region Tarih ayarları
            dtpTarih.MinDate = DateTime.Today;
            dtpTarih.MaxDate = dtpTarih.MinDate.AddDays(7);
            dtpGiris.Value = DateTime.Today;
            dtpGiris.MinDate = DateTime.Today;
            dtpCikis.MinDate = dtpGiris.MinDate.AddDays(1);
            txtGiris.Text = dtpGiris.Value.ToShortDateString();
            #endregion

            var model1 = _unitOfWork.GetRepo<Rezervasyon>().Where(x => x.RezerveMi == true).ToList();
            //var model2 = _unitOfWork.GetRepo<Rezervasyon>().Where(x => x.CikisTarihi>=DateTime.Today).Select(x=>x.OdaId).ToList();
            //var model2 = _unitOfWork.GetRepo<Oda>().GetList().Where(x => x.DoluMu == true).ToList();
            var model2 = _unitOfWork.GetRepo<Oda>().GetList();

            foreach (var item in model1)
            {
                if (DateTime.Today >= item.GirisTarihi && DateTime.Today <= item.CikisTarihi)
                {
                    _unitOfWork.GetRepo<Oda>().Where(x => x.Id == item.OdaId).FirstOrDefault().DoluMu = true;
                    _unitOfWork.Commit();

                }
            }

            foreach (var item in model2)
            {
                if (item.DoluMu == true)
                {
                    if (_unitOfWork.GetRepo<Rezervasyon>().Where(x => x.OdaId == item.Id).Select(x => x.CikisTarihi).FirstOrDefault() <= DateTime.Today)
                    {
                        item.DoluMu = false;
                        _unitOfWork.Commit();
                    }
                }
            }
            #region GroupBox1

            foreach (Control ct in groupBox1.Controls)
            {
                
                if (ct is Button && _unitOfWork.GetRepo<Oda>().Where(x => x.OdaAd == ct.Name).Select(x => x.DoluMu).FirstOrDefault() == false)
                {
                    ct.BackColor = Color.Gray;
                    ct.Text = "BOŞ";
                }
                else if (ct is Button && _unitOfWork.GetRepo<Oda>().Where(x => x.OdaAd == ct.Name).Select(x => x.DoluMu).FirstOrDefault() == true)
                {
                    ct.Text = "DOLU";
                    ct.BackColor = Color.Red;
                    ct.Enabled = false;
                }
            }

          
            #endregion

            #region GroupBox2
            foreach (Control ct in groupBox2.Controls)
            {
                if (ct is Button && _unitOfWork.GetRepo<Oda>().Where(x => x.OdaAd == ct.Name).Select(x => x.DoluMu).FirstOrDefault() == false)
                {
                    ct.BackColor = Color.Gray;
                    ct.Text = "BOŞ";
                }
                else if (ct is Button && _unitOfWork.GetRepo<Oda>().Where(x => x.OdaAd == ct.Name).Select(x => x.DoluMu).FirstOrDefault() == true)
                {
                    ct.Text = "DOLU";
                    ct.BackColor = Color.Red;
                    ct.Enabled = false;
                }
            }
                #endregion

            #region GroupBox3
                foreach (Control ct in groupBox3.Controls)
                {
                    if (ct is Button && _unitOfWork.GetRepo<Oda>().Where(x => x.OdaAd == ct.Name).Select(x => x.DoluMu).FirstOrDefault() == false)
                    {
                        ct.BackColor = Color.Gray;
                        ct.Text = "BOŞ";
                    }
                    else if (ct is Button && _unitOfWork.GetRepo<Oda>().Where(x => x.OdaAd == ct.Name).Select(x => x.DoluMu).FirstOrDefault() == true)
                    {
                        ct.Text = "DOLU";
                        ct.BackColor = Color.Red;
                        ct.Enabled = false;
                    }
                }
                #endregion

            #region GroupBox4
                foreach (Control ct in groupBox4.Controls)
                {
                    if (ct is Button && _unitOfWork.GetRepo<Oda>().Where(x => x.OdaAd == ct.Name).Select(x => x.DoluMu).FirstOrDefault() == false)
                    {
                        ct.BackColor = Color.Gray;
                        ct.Text = "BOŞ";
                    }
                    else if (ct is Button && _unitOfWork.GetRepo<Oda>().Where(x => x.OdaAd == ct.Name).Select(x => x.DoluMu).FirstOrDefault() == true)
                    {
                        ct.Text = "DOLU";
                        ct.BackColor = Color.Red;
                        ct.Enabled = false;
                    }
                }
            #endregion
         

            #region OdaTurDoldur
            var OdaTurList = _unitOfWork.GetRepo<OdaTur>().GetList();
            cbOdaTur.DataSource = OdaTurList.Select(x => new
            {
                x.Id,
                x.TurAd
            }).ToList();
            cbOdaTur.ValueMember = "Id";
            cbOdaTur.DisplayMember = "TurAd";
            cbOdaTur.SelectedItem = null;
            #endregion

            #region OdaOpsiyonDoldur
            var OzellikList = _unitOfWork.GetRepo<Ozellik>().GetList();
            cbOpsiyon.DataSource = OzellikList.Select(x => new
            {
                x.Id,
                x.OzellikAd
            }).ToList();
            cbOpsiyon.ValueMember = "Id";
            cbOpsiyon.DisplayMember = "OzellikAd";
            cbOpsiyon.SelectedItem = null;
            #endregion

            #region KatDoldur
            var KatList = _unitOfWork.GetRepo<Kat>().GetList();
            cbKat.DataSource = KatList.Select(x => new
            {
                x.Id,
                x.KatNo
            }).ToList();
            cbKat.ValueMember = "Id";
            cbKat.DisplayMember = "KatNo";

            #endregion
            //CinsiyetDoldur();

            //MedeniHalDoldur();

            //BosOdaKontrol();
            lblBosOdaSayisi.Text = _odaRepo.BosOdaSayisiBul().ToString();
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
            int ButonId = 0;
            Oda o = new Oda();
            if (btn.Text == "BOŞ")
            {
                btn.Text = "DOLU";
                btn.BackColor = Color.Red;
                ButonId =_unitOfWork.GetRepo<Oda>().Where(x => x.OdaAd==btn.Name).Select(x=>x.Id).FirstOrDefault();
                o = _unitOfWork.GetRepo<Oda>().GetById(ButonId);
                o.DoluMu = true;
                _unitOfWork.GetRepo<Oda>().Update(o);
                _unitOfWork.Commit();
            }

          else  if (btn.Text == "DOLU")
            {
                btn.Text = "BOŞ";
                btn.BackColor = Color.Lime;
                ButonId = _unitOfWork.GetRepo<Oda>().Where(x => x.OdaAd == btn.Name).Select(x => x.Id).FirstOrDefault();
                o = _unitOfWork.GetRepo<Oda>().GetById(ButonId);
                o.DoluMu = false;
                _unitOfWork.GetRepo<Oda>().Update(o);
                _unitOfWork.Commit();
            }
            lblBosOdaSayisi.Text = _odaRepo.BosOdaSayisiBul().ToString();
        }

        private void cbOdaTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOdaTur.SelectedValue != null && cbOpsiyon.SelectedValue != null)
            {
                int fiyatId = _unitOfWork.GetRepo<Fiyat>().Where(x => x.OzellikId == (int)cbOpsiyon.SelectedValue && x.OdaTurId == (int)cbOdaTur.SelectedValue).FirstOrDefault().Id;
                #region ButonKontrolleri
                foreach (Control ct in groupBox1.Controls)
                {
                    if (ct is Button && ct.BackColor == Color.Gray && _unitOfWork.GetRepo<Oda>().Where(x => x.OdaAd == ct.Name).Select(x => x.FiyatId).FirstOrDefault() == fiyatId)
                    {
                        ct.BackColor = Color.Lime;

                    }
                    else if (ct.BackColor == Color.Lime)
                    {
                        ct.BackColor = Color.Gray;
                    }
                }

                foreach (Control ct in groupBox2.Controls)
                {
                    if (ct is Button && ct.BackColor == Color.Gray && _unitOfWork.GetRepo<Oda>().Where(x => x.OdaAd == ct.Name).Select(x => x.FiyatId).FirstOrDefault() == fiyatId)
                    {
                        ct.BackColor = Color.Lime;

                    }
                    else if (ct.BackColor == Color.Lime)
                    {
                        ct.BackColor = Color.Gray;
                    }
                }

                foreach (Control ct in groupBox3.Controls)
                {
                    if (ct is Button && ct.BackColor == Color.Gray && _unitOfWork.GetRepo<Oda>().Where(x => x.OdaAd == ct.Name).Select(x => x.FiyatId).FirstOrDefault() == fiyatId)
                    {
                        ct.BackColor = Color.Lime;

                    }
                    else if (ct.BackColor == Color.Lime)
                    {
                        ct.BackColor = Color.Gray;
                    }
                }

                foreach (Control ct in groupBox4.Controls)
                {
                    if (ct is Button && ct.BackColor == Color.Gray && _unitOfWork.GetRepo<Oda>().Where(x => x.OdaAd == ct.Name).Select(x => x.FiyatId).FirstOrDefault() == fiyatId)
                    {
                        ct.BackColor = Color.Lime;

                    }
                    else if (ct.BackColor == Color.Lime)
                    {
                        ct.BackColor = Color.Gray;
                    }
                } 
                #endregion
            }
        }

        private void cbOpsiyon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOdaTur.SelectedValue != null && cbOpsiyon.SelectedValue != null)
            {
                int fiyatId2 = _unitOfWork.GetRepo<Fiyat>().Where(x => x.OzellikId == (int)cbOpsiyon.SelectedValue && x.OdaTurId == (int)cbOdaTur.SelectedValue).FirstOrDefault().Id;
                #region ButonKontrolleri
                foreach (Control ct in groupBox1.Controls)
                {
                    if (ct is Button && ct.BackColor == Color.Gray && _unitOfWork.GetRepo<Oda>().Where(x => x.OdaAd == ct.Name).Select(x => x.FiyatId).FirstOrDefault() == fiyatId2)
                    {
                        ct.BackColor = Color.Lime;

                    }
                    else if (ct.BackColor == Color.Lime)
                    {
                        ct.BackColor = Color.Gray;
                    }
                }

                foreach (Control ct in groupBox2.Controls)
                {
                    if (ct is Button && ct.BackColor == Color.Gray && _unitOfWork.GetRepo<Oda>().Where(x => x.OdaAd == ct.Name).Select(x => x.FiyatId).FirstOrDefault() == fiyatId2)
                    {
                        ct.BackColor = Color.Lime;

                    }
                    else if (ct.BackColor == Color.Lime)
                    {
                        ct.BackColor = Color.Gray;
                    }
                }

                foreach (Control ct in groupBox3.Controls)
                {
                    if (ct is Button && ct.BackColor == Color.Gray && _unitOfWork.GetRepo<Oda>().Where(x => x.OdaAd == ct.Name).Select(x => x.FiyatId).FirstOrDefault() == fiyatId2)
                    {
                        ct.BackColor = Color.Lime;

                    }
                    else if (ct.BackColor == Color.Lime)
                    {
                        ct.BackColor = Color.Gray;
                    }
                }

                foreach (Control ct in groupBox4.Controls)
                {
                    if (ct is Button && ct.BackColor == Color.Gray && _unitOfWork.GetRepo<Oda>().Where(x => x.OdaAd == ct.Name).Select(x => x.FiyatId).FirstOrDefault() == fiyatId2)
                    {
                        ct.BackColor = Color.Lime;

                    }
                    else if (ct.BackColor == Color.Lime)
                    {
                        ct.BackColor = Color.Gray;
                    }
                }
                #endregion
            }
        }
    }
}
