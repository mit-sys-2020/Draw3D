using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Draw3D
{
    public partial class frmTest : Form
    {

        public clsCbIni cb_ini_str = new clsCbIni();
        public clsCbXY cb_xy_p = new clsCbXY();
        public clsCbRol cb_rol_str = new clsCbRol();
        public clsCbVer cb_ver_str = new clsCbVer();

        frmView     fView;
        clsDraw     lpDraw;

        public frmTest()
        {
            InitializeComponent();
            setData();
            fView = new frmView();
            lpDraw = new clsDraw(cb_ini_str, cb_xy_p, cb_rol_str, cb_ver_str);
            fView._setviewport(0, 0, 399, 399);

            cmbBkCol1.SelectedIndex = 0;
            txtAngXZ.Text = "30";
            txtAngXY.Text = "30";
            cmbBkCol2.SelectedIndex = 0;
            cmbDir2.SelectedIndex = 0;
            txtAng2.Text = "30";
            txtXLin3.Text = "1";
            txtYLin3.Text = "1";
            cmbCur3.SelectedIndex = 0;
            fView.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fView.IsDisposed)
            {
                fView = new frmView();
                fView.Show();
            }
            int cur_p = tabInput.SelectedIndex;
            if (cur_p == 0)
            {
                cb_ini_str.bk_col     = cmbBkCol1.SelectedIndex;
                cb_ini_str.view_xz    = int.Parse( txtAngXZ.Text );
                cb_ini_str.view_xy    = int.Parse( txtAngXY.Text );
                lpDraw.init_disp(fView);
            }
            else if (cur_p == 1)
            {
                cb_ini_str.bk_col = cmbBkCol2.SelectedIndex;
                cb_rol_str.direction = cmbDir2.SelectedIndex;
                cb_rol_str.angle = int.Parse(txtAng2.Text);
                lpDraw.rotate_z(fView);
            }
            else if (cur_p == 2)
            {

                cb_ini_str.cur_flg = 1;
                cb_ini_str.cur_col[0] = 5;
                cb_ini_str.cur_col[1] = 1;
                cb_ver_str.xsen = 3;
                cb_ver_str.ysen = 5;
                cb_ver_str.xsen = int.Parse(txtXLin3.Text);
                cb_ver_str.ysen = int.Parse(txtYLin3.Text);
                cb_rol_str.direction = cmbCur3.SelectedIndex;
                lpDraw.init_disp(fView);
                lpDraw.ver_line(fView);
            }
        }

        private void setData()
        {
            int i, j;
            //  初期化

            //  テストデータの設定
            cb_ini_str.vp_ep.y = 0;
            cb_ini_str.vp_sp.y = 400;
            cb_ini_str.vp_ep.x = 400;
            cb_ini_str.vp_sp.x = 0;

            cb_ini_str.view_xz = 0;
            cb_ini_str.view_xy = 0;

            cb_ini_str.wak_flg = 1;
            cb_ini_str.waku_col = 7;
            cb_ini_str.waku_fnt = 0xffff;
            cb_ini_str.waku_max[0] = 4000;
            cb_ini_str.waku_max[1] = 2000;
            cb_ini_str.waku_max[2] = 4000;
            cb_ini_str.waku_zmin = -1000;

            cb_ini_str.ax_titl[0] = "Ｘ軸";
            cb_ini_str.ax_titl[1] = "Ｙ軸";
            cb_ini_str.ax_titl[2] = "Ｚ軸";

            cb_ini_str.pl_fnt[0] = 0xffff;	//Ｘ正線種類（x0000～xffff）
            cb_ini_str.pl_col[0] = 3;	//Ｘ正線カラー（0～7）
            cb_ini_str.ml_fnt[0] = 0xeeee;	//Ｘ負線種類（x0000～xffff）
            cb_ini_str.ml_col[0] = 6;	//Ｘ負線カラー（0～7）
            cb_ini_str.pl_fnt[1] = 0xffff;	//Ｙ正線種類（x0000～xffff）
            cb_ini_str.pl_col[1] = 3;	//Ｙ正線カラー（0～7）
            cb_ini_str.ml_fnt[1] = 0xeeee;	//Ｙ負線種類（x0000～xffff）
            cb_ini_str.ml_col[1] = 6;	//Ｙ負線カラー（0～7）
            cb_ini_str.pl_fnt[2] = 0xffff;	//Ｚ正線種類（x0000～xffff）
            cb_ini_str.pl_col[2] = 4;	//Ｚ正線カラー（0～7）
            cb_ini_str.ml_fnt[2] = 0xeeee;	//Ｚ負線種類（x0000～xffff）
            cb_ini_str.ml_col[2] = 4;	//Ｚ負線カラー（0～7）
            cb_ini_str.xy_cnt[0] = 5;
            cb_ini_str.xy_cnt[1] = 7;

            for (i = 0; i < cb_ini_str.xy_cnt[1]; i++)
            {
                cb_ini_str.x[i] = (int)(cb_ini_str.waku_max[0] * i
                             / (cb_ini_str.xy_cnt[1] - 1));
                for (j = 0; j < cb_ini_str.xy_cnt[0]; j++)
                {
                    cb_ini_str.y[j] = (int)(cb_ini_str.waku_max[1] * j
                                / (cb_ini_str.xy_cnt[0] - 1));

                    cb_ini_str.z[j * cb_ini_str.xy_cnt[1] + i]
                    = (int)((double)2.0
                    * (System.Math.Pow((double)cb_ini_str.x[i] / (double)200.0, (double)2.0)
                    + (double)2.0
                    * System.Math.Pow((double)cb_ini_str.y[j] / (double)200.0, (double)2.0)));
                }
            }
        }

        private void cmbBkCol2SelChange(object sender, EventArgs e)
        {
            cmbBkCol1.SelectedIndex = cmbBkCol2.SelectedIndex;
        }

        private void cmbBkCol1SelChange(object sender, EventArgs e)
        {
            cmbBkCol2.SelectedIndex = cmbBkCol1.SelectedIndex;
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
