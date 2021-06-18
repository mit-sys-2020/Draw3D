using System;

namespace Draw3D
{
	/// <summary>
	/// clsData の概要の説明です。
	/// </summary>
	public class clsCbIni
	{
        public clsPnt   vp_sp;	    //ビューポート左下
        public clsPnt   vp_ep;	    //ビューポート右上
        public int      view_xz;	//視点角度（緯度方向ＸＺ角度）
        public int      view_xy;    //視点角度（経度方向ＸＹ角度）
        public int      bk_col;	    //背景色（0～7）
        public int      wak_flg;	//枠出力オプション(0：しない, 1:する)
        public int[]    waku_max;   //枠最大値（x0000～xffff）([0]:X軸, [1]:Y軸, [2]:Z軸)
        public int      waku_zmin;  //枠最小値（Ｚ軸）
        public int      waku_fnt;	//枠線種類（x0000～xffff）
        public int      waku_col;	//枠線カラー（0～7）
        public string[] ax_titl;    //軸タイトル([0]:X, [1]:Y, [2]:Z)
        public int[]    pl_fnt;     //正線種類（x0000～xffff）([0]:X, [1]:Y, [2]:Z)
        public int[]    ml_fnt;     //負線種類（x0000～xffff）([0]:X, [1]:Y, [2]:Z)
        public int[]    pl_col;     //正線カラー（0～7）([0]:X, [1]:Y, [2]:Z)
        public int[]    ml_col;     //負線カラー（0～7）([0]:X, [1]:Y, [2]:Z)
		public int[]    xy_cnt;		//Ｘ線数（１以上）
		public int[]    x;		    //Ｘ座標配列（[xy_cnt[0]]）
		public int[]    y;		    //Ｙ座標配列（[xy_cnt[1]]）
		public int[]	z;          //Ｚ座標配列（[xy_cnt[0]][xy_cnt[1]]）
        public int[]    cur_col;    //カーソルのカラー（0～7）([0]:X, [1]:Y)
		public int	    cur_flg;    //カーソル垂線出力オプション (0：しない, 1:する)

	    public  clsCbIni()
        {
            waku_max = new int[3];		                //枠最大値
            ax_titl = new string[3];	                //軸タイトル
            pl_fnt = new int[3];		                //正線種類
            ml_fnt = new int[3];		                //負線種類
            pl_col = new int[3];		                //正線カラー
            ml_col = new int[3];		                //負線カラー
            xy_cnt = new int[2];		                //カーソルのカラー
            x = new int[clsCom.XSU];	                //Ｘ座標配列
            y = new int[clsCom.YSU];	                //Ｙ座標配列
            z = new int[clsCom.YSU * clsCom.XSU];		//Ｚ座標配列
            cur_col = new int[2];		                //カーソルのカラー
            vp_sp = new clsPnt();
            vp_ep = new clsPnt();
        }
    }

	public class clsCbXY
	{
        public int[] x_p;		//スクリーンＸ座標
        public int[] y_p;		//スクリーンＹ座標
        public clsCbXY()
        {
            x_p = new int[clsCom.XSU * clsCom.YSU];
            y_p = new int[clsCom.XSU * clsCom.YSU];
        }
	}

	public class clsCbRol
	{
        public int direction;   //回転方向（0:時計回り, 1:反時計回り）
        public int angle;	    //回転角度（0～180度）
	}

	public class clsCbVer
	{
        public int xsen;	//変更するＸ線の番号（1～xy_cnt[0]）
        public int ysen;	//変更するＹ線の番号（1～xy_cnt[1]）
	}
}

