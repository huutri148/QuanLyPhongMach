﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyPhongMach
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public void SkinDefault()
        {
            DevExpress.LookAndFeel.DefaultLookAndFeel themes = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            themes.LookAndFeel.SkinName = "Valentine";
        }

        private void btnBenhNhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool _IsActive = false;
            foreach (Form form in Application.OpenForms.OfType<Form>().ToList())
            {
                if (form.GetType() == typeof(frmDanhSachKhamBenh))
                {
                    form.Activate();
                    _IsActive = true;
                }
            }
            if (!_IsActive)
            {
                frmDanhSachKhamBenh frm = new frmDanhSachKhamBenh();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnPhieuKham_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool _IsActive = false;
            foreach (Form form in Application.OpenForms.OfType<Form>().ToList())
            {
                if (form.GetType() == typeof(frmPhieuKhamBenh))
                {
                    form.Activate();
                    _IsActive = true;
                }
            }
            if (!_IsActive)
            {
                frmPhieuKhamBenh frm = new frmPhieuKhamBenh();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        #region PHẦN CHIA NGƯỜI DÙNG
        private void frmMain_Load(object sender, EventArgs e)
        {
            SkinDefault();
            OnOff(this);
        }

        public void OnOff(Form frm)
        {
            frmMain f = (frmMain)frm;
            switch (PhanQuyenNguoiDung.ChucVu)
            {
                case "Admin":
                    {
                        f.btnDangNhap.Enabled = false;
                        f.btnDangXuat.Enabled = true;
                        f.btnDoiMatKhau.Enabled = true;
                        f.btnThayDoiThongTinCaNhan.Enabled = true;
                        f.btnQuanLyNguoiDung.Enabled = true;
                        f.btnBaoCaoSuDungThuoc.Enabled = true;
                        f.btnBaoCaoDoanhThu.Enabled = true;
                        f.btnBenhNhan.Enabled = true;
                        f.btnPhieuKham.Enabled = true;
                        f.btnTraCuuBenhNhan.Enabled = true;
                        f.btnThuoc.Enabled = true;
                        f.btnDangNhap.Caption = PhanQuyenNguoiDung.ChucVu;
                        f.btnDangXuat.Caption = "Đăng xuất " + "'" + PhanQuyenNguoiDung.TenDangNhap + "'";
                    }
                    break;
                case "Nhân Viên":
                    {
                        f.btnDangNhap.Enabled = false;
                        f.btnDangXuat.Enabled = true;
                        f.btnDoiMatKhau.Enabled = true;
                        f.btnThayDoiThongTinCaNhan.Enabled = true;
                        f.btnQuanLyNguoiDung.Enabled = false;
                        f.btnBaoCaoSuDungThuoc.Enabled = false;
                        f.btnBaoCaoDoanhThu.Enabled = false;
                        f.btnBenhNhan.Enabled = true;
                        f.btnPhieuKham.Enabled = true;
                        f.btnTraCuuBenhNhan.Enabled = true;
                        f.btnThuoc.Enabled = true;
                        f.btnDangNhap.Caption = PhanQuyenNguoiDung.ChucVu;
                        f.btnDangXuat.Caption = "Đăng xuất " + "'" + PhanQuyenNguoiDung.TenDangNhap + "'";
                    }
                    break;
                default:
                    {
                        f.btnDangNhap.Enabled = true;
                        f.btnDangXuat.Enabled = false;
                        f.btnDoiMatKhau.Enabled = false;
                        f.btnThayDoiThongTinCaNhan.Enabled = false;
                        f.btnQuanLyNguoiDung.Enabled = false;
                        f.btnBaoCaoSuDungThuoc.Enabled = false;
                        f.btnBaoCaoDoanhThu.Enabled = false;
                        f.btnBenhNhan.Enabled = false;
                        f.btnPhieuKham.Enabled = false;
                        f.btnTraCuuBenhNhan.Enabled = false;
                        f.btnThuoc.Enabled = false;
                        f.btnDangNhap.Caption = "Đăng nhập";
                        f.btnDangXuat.Caption = "Đăng xuất ";
                    }
                    break;
            }
        }
        #endregion

        #region HỆ THỐNG
        private void btnDangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            frm.ShowDialog();
        }

        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất hay không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                foreach (Form frm in this.MdiChildren)
                    frm.Close();
                PhanQuyenNguoiDung.ChucVu = "";
                PhanQuyenNguoiDung.TenDangNhap = "";
                OnOff(this);
            }
        }

        private void btnDoiMatKhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.ShowDialog();
        }

        private void btnThayDoiThongTinCaNhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCapNhatThongTinNguoiDung frm = new frmCapNhatThongTinNguoiDung();
            frm.ShowDialog();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng hay không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnQuanLyNguoiDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool _IsActive = false;
            foreach (Form form in Application.OpenForms.OfType<Form>().ToList())
            {
                if (form.GetType() == typeof(frmQuanLyNguoiDung))
                {
                    form.Activate();
                    _IsActive = true;
                }
            }
            if (!_IsActive)
            {
                frmQuanLyNguoiDung frm = new frmQuanLyNguoiDung();
                frm.MdiParent = this;
                frm.Show();
            }
        }
        #endregion

    }
}
