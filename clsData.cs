using System;

namespace Draw3D
{
	/// <summary>
	/// clsData �̊T�v�̐����ł��B
	/// </summary>
	public class clsCbIni
	{
        public clsPnt   vp_sp;	    //�r���[�|�[�g����
        public clsPnt   vp_ep;	    //�r���[�|�[�g�E��
        public int      view_xz;	//���_�p�x�i�ܓx�����w�y�p�x�j
        public int      view_xy;    //���_�p�x�i�o�x�����w�x�p�x�j
        public int      bk_col;	    //�w�i�F�i0�`7�j
        public int      wak_flg;	//�g�o�̓I�v�V����(0�F���Ȃ�, 1:����)
        public int[]    waku_max;   //�g�ő�l�ix0000�`xffff�j([0]:X��, [1]:Y��, [2]:Z��)
        public int      waku_zmin;  //�g�ŏ��l�i�y���j
        public int      waku_fnt;	//�g����ށix0000�`xffff�j
        public int      waku_col;	//�g���J���[�i0�`7�j
        public string[] ax_titl;    //���^�C�g��([0]:X, [1]:Y, [2]:Z)
        public int[]    pl_fnt;     //������ށix0000�`xffff�j([0]:X, [1]:Y, [2]:Z)
        public int[]    ml_fnt;     //������ށix0000�`xffff�j([0]:X, [1]:Y, [2]:Z)
        public int[]    pl_col;     //�����J���[�i0�`7�j([0]:X, [1]:Y, [2]:Z)
        public int[]    ml_col;     //�����J���[�i0�`7�j([0]:X, [1]:Y, [2]:Z)
		public int[]    xy_cnt;		//�w�����i�P�ȏ�j
		public int[]    x;		    //�w���W�z��i[xy_cnt[0]]�j
		public int[]    y;		    //�x���W�z��i[xy_cnt[1]]�j
		public int[]	z;          //�y���W�z��i[xy_cnt[0]][xy_cnt[1]]�j
        public int[]    cur_col;    //�J�[�\���̃J���[�i0�`7�j([0]:X, [1]:Y)
		public int	    cur_flg;    //�J�[�\�������o�̓I�v�V���� (0�F���Ȃ�, 1:����)

	    public  clsCbIni()
        {
            waku_max = new int[3];		                //�g�ő�l
            ax_titl = new string[3];	                //���^�C�g��
            pl_fnt = new int[3];		                //�������
            ml_fnt = new int[3];		                //�������
            pl_col = new int[3];		                //�����J���[
            ml_col = new int[3];		                //�����J���[
            xy_cnt = new int[2];		                //�J�[�\���̃J���[
            x = new int[clsCom.XSU];	                //�w���W�z��
            y = new int[clsCom.YSU];	                //�x���W�z��
            z = new int[clsCom.YSU * clsCom.XSU];		//�y���W�z��
            cur_col = new int[2];		                //�J�[�\���̃J���[
            vp_sp = new clsPnt();
            vp_ep = new clsPnt();
        }
    }

	public class clsCbXY
	{
        public int[] x_p;		//�X�N���[���w���W
        public int[] y_p;		//�X�N���[���x���W
        public clsCbXY()
        {
            x_p = new int[clsCom.XSU * clsCom.YSU];
            y_p = new int[clsCom.XSU * clsCom.YSU];
        }
	}

	public class clsCbRol
	{
        public int direction;   //��]�����i0:���v���, 1:�����v���j
        public int angle;	    //��]�p�x�i0�`180�x�j
	}

	public class clsCbVer
	{
        public int xsen;	//�ύX����w���̔ԍ��i1�`xy_cnt[0]�j
        public int ysen;	//�ύX����x���̔ԍ��i1�`xy_cnt[1]�j
	}
}

