using System;

namespace Draw3D
{
	/// <summary>
	/// clsDraw の概要の説明です。
	/// </summary>
	public class clsDraw
	{
        frmView       lpView;
        public double[,] Tvps = new double[4, 4];		//座標変換マトリックス
        public double[,] Tmvps = new double[4, 4];	    //座標変換マトリックス
        clsCbIni      cb_ini_str;
        clsCbXY       cb_xy_p;
        clsCbRol      cb_rol_str;
        clsCbVer      cb_ver_str;

        public clsDraw(clsCbIni ini_str, clsCbXY xy_p, clsCbRol rol_str, clsCbVer ver_str)
		{
            cb_ini_str  = ini_str;
            cb_xy_p     = xy_p;
            cb_rol_str  = rol_str;
            cb_ver_str  = ver_str;
        }

        //  初期表示
        //  frmView     p_frm   (i)	表示用フォーム
        //  戻り値                  正常=0, エラー=1
        public int init_disp(frmView p_frm)
        {
		    int	i, j;
		    int[] waku_x  = new int[12];
            int[] waku_y  = new int [12];
            int[] waku_z = new int[12];
            int[] w_sx = new int[12];
		    int[] w_sy    = new int[12];

            lpView = p_frm;
            lpView._setcolor(cb_ini_str.bk_col);
            lpView._clearscreen();

// 座標変換マトリックス
	        get_Tvps( cb_ini_str, Tvps );
	        for( i=0; i<4; i++ )
	        {
	           for( j=0; j<4; j++ )		Tmvps[i,j] = Tvps[i,j];
	        }

// データの表示
	        for( i=0; i<cb_ini_str.xy_cnt[1]; i++ )
	        {
	           for( j=0; j<cb_ini_str.xy_cnt[0]; j++ )
	           {
		        pnt_to_scrn( cb_ini_str.x[i], cb_ini_str.y[j],
			          cb_ini_str.z[j*(cb_ini_str.xy_cnt[1])+i], Tvps,
			          out cb_xy_p.x_p[j*(cb_ini_str.xy_cnt[1])+i], 
			          out cb_xy_p.y_p[j*(cb_ini_str.xy_cnt[1])+i] );
	           }
	        }
	        disp_data( );

// 枠の表示
	        if( cb_ini_str.wak_flg == 1 )
	        {
	           get_waku_cood( cb_ini_str.waku_max[0], cb_ini_str.waku_max[1],
	   		         cb_ini_str.waku_max[2], cb_ini_str.waku_zmin,
			         waku_x, waku_y, waku_z );
	           for( i=0; i<12; i++ )
	           {
	   	        pnt_to_scrn( waku_x[i], waku_y[i], waku_z[i], Tvps, out w_sx[i], out w_sy[i] );
	           }
	           disp_waku( cb_ini_str, w_sx, w_sy );
	        }
            lpView._refresh();

	        return( 0 );
        }

        //  Ｚ軸回りの回転表示
        //  frmView     p_frm   (i)	表示用フォーム
        //  戻り値                  正常=0, エラー=1
        public int rotate_z(frmView p_frm)
        {
	        int	i, j;
		    int[] waku_x  = new int[12];
            int[] waku_y  = new int [12];
            int[] waku_z  = new int [12];
		    int[] w_sx    = new int[12];
		    int[] w_sy    = new int[12];
	        double	xc, yc, sign, angle;
	        double[,]	Tm = new double[4,4];

            lpView = p_frm;
            // 初期設定
            lpView._setcolor(cb_ini_str.bk_col);
            lpView._clearscreen();

            xc = cb_ini_str.waku_max[0]/(double)2.0;
            yc = cb_ini_str.waku_max[1]/(double)2.0;
            angle = (double)(cb_rol_str.angle) / (double)180.0 * clsCom.PAI;
	        if( cb_rol_str.direction == 0 )	sign = (double)(-1.0);
	        else					sign = (double)1.0;

        // 座標変換マトリックスの求め
            Tm[0, 0] = System.Math.Cos(angle);
            Tm[0, 1] = sign * System.Math.Sin(angle);
	        Tm[0, 2] = (double)0.0;
	        Tm[0, 3] = (double)0.0;
            Tm[1, 0] = -sign * System.Math.Sin(angle);
            Tm[1, 1] = System.Math.Cos(angle);
	        Tm[1, 2] = (double)0.0;
	        Tm[1, 3] = (double)0.0;
	        Tm[2, 0] = (double)0.0;
	        Tm[2, 1] = (double)0.0;
	        Tm[2, 2] = (double)1.0;
	        Tm[2, 3] = (double)0.0;
            Tm[3, 0] = xc * (1 - System.Math.Cos(angle)) + yc * (sign * System.Math.Sin(angle));
            Tm[3, 1] = yc * (1 - System.Math.Cos(angle)) - xc * (sign * System.Math.Sin(angle));
	        Tm[3, 2] = (double)0.0;
	        Tm[3, 3] = (double)1.0;

            calc_matr(Tm, 4, 4, Tvps, 4, 4, Tmvps);

        // データの表示
	        for( i=0; i<cb_ini_str.xy_cnt[1]; i++ )
	        {
	           for( j=0; j<cb_ini_str.xy_cnt[0]; j++ )
	           {
		        pnt_to_scrn( cb_ini_str.x[i], cb_ini_str.y[j],
			          cb_ini_str.z[j*(cb_ini_str.xy_cnt[1])+i], Tmvps,
			          out (cb_xy_p.x_p[j*(cb_ini_str.xy_cnt[1])+i]), 
			          out (cb_xy_p.y_p[j*(cb_ini_str.xy_cnt[1])+i]) );
	           }
	        }
	        disp_data( );

        // 枠の表示
	        if( cb_ini_str.wak_flg == 1 )
	        {
	           get_waku_cood( cb_ini_str.waku_max[0], cb_ini_str.waku_max[1],
	   		         cb_ini_str.waku_max[2], cb_ini_str.waku_zmin,
			         waku_x, waku_y, waku_z );
	           for( i=0; i<12; i++ )
	           {
	   	        pnt_to_scrn( waku_x[i], waku_y[i], waku_z[i], Tmvps,
						        out w_sx[i], out w_sy[i] );
	           }
	           disp_waku( cb_ini_str, w_sx, w_sy );
	        }
            lpView._refresh();

	        return( 0 );
        }

        //  カーソルのＸ・Ｙ位置指定
        //  frmView     p_frm   (i)	表示用フォーム
        //  戻り値                  正常=0, エラー=1
        public int ver_line(frmView p_frm)
        {
	        int	i, color, style, xo, yo;


        // 元データの呼び出し
        //	load( );

        // Ｘ線の表示
	        for( i=0; i<cb_ini_str.xy_cnt[1]-1; i++ )
	        {
	           disp_line( 3, i, cb_ver_str.xsen-1, i+1,
			        cb_ver_str.xsen-1, cb_ini_str.xy_cnt[1], Tmvps );
	        }

        // Ｙ線の表示

	        for( i=0; i<cb_ini_str.xy_cnt[0]-1; i++ )
	        {
	           disp_line( 4, cb_ver_str.ysen-1, i,
			        cb_ver_str.ysen-1, i+1, cb_ini_str.xy_cnt[1], Tmvps );
	        }

        // 垂線を描く
	        if( cb_ini_str.cur_flg == 1 )
	        {
	           if( cb_ini_str.z[(cb_ver_str.ysen-1)*cb_ini_str.xy_cnt[1]
					        +cb_ver_str.xsen-1] >= 0 )
	           {
       		        color = cb_ini_str.pl_col[2];
	       	        style = cb_ini_str.pl_fnt[2];
	           }
	           else
	           {
       		        color = cb_ini_str.ml_col[2];
	       	        style = cb_ini_str.ml_fnt[2];
	           }

	           pnt_to_scrn( cb_ini_str.x[cb_ver_str.ysen-1],
	   	             cb_ini_str.y[cb_ver_str.xsen-1],
						        0, Tmvps, out xo, out yo );

	           draw_line( cb_xy_p.x_p[(cb_ver_str.xsen-1)*cb_ini_str.xy_cnt[1]
	   					        +cb_ver_str.ysen-1],
	   	            cb_xy_p.y_p[(cb_ver_str.xsen-1)*cb_ini_str.xy_cnt[1]
	   					        +cb_ver_str.ysen-1],
		    					        xo, yo, color, style );
	        }
            lpView._refresh();

	        return( 0 );
        }


        //  データの表示
        //  戻り値                      正常=0, エラー=1
        int	disp_data( )
        {
	        int	i, j;


	        for( j=0; j<cb_ini_str.xy_cnt[0]; j++ )	//  X線
	        {
	           for( i=0; i<cb_ini_str.xy_cnt[1]-1; i++ )
	           {
		        disp_line( 1, i, j, i+1, j, cb_ini_str.xy_cnt[1], Tmvps );
	           }
	        }

	        for( i=0; i<cb_ini_str.xy_cnt[1]; i++ )	//  Y線
	        {
	           for( j=0; j<cb_ini_str.xy_cnt[0]-1; j++ )
	           {
		        disp_line( 2, i, j, i, j+1, cb_ini_str.xy_cnt[1], Tmvps );
	           }
	        }

	        return( 0 );
        }


        //  データの表示
        //  int	        mode        (i)	1=Ｘ線, 2=Ｙ線, 3=指定Ｘ線, 4=指定Ｙ線
        //  int	        i1, j1;		(i)	始点のＸＹ番号
        //  int	        i2, j2;		(i)	終点のＸＹ番号
        //  int	        m;			(i)	座標配列の行数
        //  double	    T[][4];		(i)	座標変換マトリックス
        //  戻り値                      正常=0, エラー=1
        int	disp_line( int mode, int i1, int j1, int i2, int j2, int m, double[,] T )
        {
	        int	sign, color, style, color1, style1,
		        xw, yw, zw, xs, ys;

            color = 0;
            style = 0;
            color1 = 0;
            style1 = 0;
            // モードにより色、線種の指定

	        switch( mode )
	        {
	            case	1:
		            color = cb_ini_str.pl_col[0];
   		            style = cb_ini_str.pl_fnt[0];
		            color1 = cb_ini_str.ml_col[0];
   		            style1 = cb_ini_str.ml_fnt[0];
		            break;
	            case	2:
		            color = cb_ini_str.pl_col[1];
   		            style = cb_ini_str.pl_fnt[1];
		            color1 = cb_ini_str.ml_col[1];
   		            style1 = cb_ini_str.ml_fnt[1];
		            break;
	            case	3:
		            color = cb_ini_str.cur_col[0];
   		            style = cb_ini_str.pl_fnt[0];
		            color1 = color;
   		            style1 = cb_ini_str.ml_fnt[0];
		            break;
	            case	4:
		            color = cb_ini_str.cur_col[1];
		            style = cb_ini_str.pl_fnt[1];
		            color1 = color;
		            style1 = cb_ini_str.ml_fnt[1];
		            break;
	        }

	        if( cb_ini_str.z[j1*m+i1]>=0 && cb_ini_str.z[j2*m+i2]>=0 ||
	            cb_ini_str.z[j1*m+i1]<=0 && cb_ini_str.z[j2*m+i2]<=0 )
		        sign = 1;
	        else
		        sign = -1;

        // 正線か負線の描画
	        if ( sign > 0 )
	        {
	           if ( cb_ini_str.z[j1*m+i1] >= 0 )
	           {
   	   	        draw_line( cb_xy_p.x_p[j1*m+i1], cb_xy_p.y_p[j1*m+i1],
		    	         cb_xy_p.x_p[j2*m+i2], cb_xy_p.y_p[j2*m+i2],
								        color, style );
	           }
	           else
	           {
   	   	        draw_line( cb_xy_p.x_p[j1*m+i1], cb_xy_p.y_p[j1*m+i1],
		    	         cb_xy_p.x_p[j2*m+i2], cb_xy_p.y_p[j2*m+i2],
							             color1, style1 );
	           }
	        }
	        else

        // 正線と負線を分けて、描画
	        {
	           get_xyz_o( cb_ini_str.x[i1], cb_ini_str.y[j1],
		             cb_ini_str.z[j1*m+i1], cb_ini_str.x[i2],
		             cb_ini_str.y[j2], cb_ini_str.z[j2*m+i2],
			     				        out xw, out yw, out zw );
	           pnt_to_scrn( xw, yw, zw, T, out xs, out ys );

	           if ( cb_ini_str.z[j1*m+i1] >= 0 )
	           {
		        draw_line( cb_xy_p.x_p[j1*m+i1], cb_xy_p.y_p[j1*m+i1],
				 		        xs, ys, color, style );

		        draw_line( cb_xy_p.x_p[j2*m+i2], cb_xy_p.y_p[j2*m+i2],
				 		        xs, ys, color1, style1 );
	           }
	           else
	           {
		        draw_line( cb_xy_p.x_p[j1*m+i1], cb_xy_p.y_p[j1*m+i1],
				 		            xs, ys, color1, style1 );
		        draw_line( cb_xy_p.x_p[j2*m+i2], cb_xy_p.y_p[j2*m+i2],
				 		            xs, ys, color, style );
	           }
	        }

	        return( 0 );
        }

        //  枠とタイトルの表示
        //  clsCbIni    cb_ini_str  (i)	表示用パラメータ及びデータ
        //  int	        sx, sy;		(i)	枠のスクリ－ン座標
        //  戻り値                      正常=0, エラー=1
        int	disp_waku( clsCbIni cb_ini_str, int[] sx, int[] sy )
        {
	        int	i, j;


        // 枠の表示
	        for( i=0; i<12; i++ )
	        {
	           if( (i+1)%4 == 0 )	j = i-3;
	           else			j = i+1;

	           draw_line( sx[i], sy[i],
	   	            sx[j], sy[j],
		            cb_ini_str.waku_col, cb_ini_str.waku_fnt );
	        }
	        for( i=0; i<4; i++ )
	        {

	           draw_line( sx[i], sy[i],
	   	            sx[i+8], sy[i+8],
		            cb_ini_str.waku_col, cb_ini_str.waku_fnt );
	        }

        // タイトルの表示
	        draw_text( sx[4], sy[4],
		         sx[5], sy[5],
		         cb_ini_str.ax_titl[0], cb_ini_str.waku_col );

	        draw_text( sx[4], sy[4],
		         sx[7], sy[7],
		         cb_ini_str.ax_titl[1], cb_ini_str.waku_col );

	        draw_text( sx[4], sy[4],
		         sx[8], sy[8],
		         cb_ini_str.ax_titl[2], cb_ini_str.waku_col );

	        return( 0 );
        }

        //  枠の座標を求める
        //  int	xp;				        (i)	枠最大値（Ｘ軸）
        //  int	yp;				        (i)	枠最大値（Ｙ軸）
        //  int	zp, zm;				    (i)	枠最大、最小値（Ｚ軸）
        //  int	*waku_x, *waku_y, *waku_z;	(o)	枠の座標
        //  戻り値                      正常=0, エラー=1
        int	get_waku_cood( int xp, int yp, int zp, int zm, int[] waku_x, int[] waku_y,  int[] waku_z )
        {
	        waku_x[0] = 0;
	        waku_y[0] = 0;
	        waku_z[0] = zm;
	        waku_x[1] = xp;
	        waku_y[1] = 0;
	        waku_z[1] = zm;
	        waku_x[2] = xp;
	        waku_y[2] = yp;
	        waku_z[2] = zm;
	        waku_x[3] = 0;
	        waku_y[3] = yp;
	        waku_z[3] = zm;
	        waku_x[4] = 0;
	        waku_y[4] = 0;
	        waku_z[4] = 0;
	        waku_x[5] = xp;
	        waku_y[5] = 0;
	        waku_z[5] = 0;
	        waku_x[6] = xp;
	        waku_y[6] = yp;
	        waku_z[6] = 0;
	        waku_x[7] = 0;
	        waku_y[7] = yp;
	        waku_z[7] = 0;
	        waku_x[8] = 0;
	        waku_y[8] = 0;
	        waku_z[8] = zp;
	        waku_x[9] = xp;
	        waku_y[9] = 0;
	        waku_z[9] = zp;
	        waku_x[10] = xp;
	        waku_y[10] = yp;
	        waku_z[10] = zp;
	        waku_x[11] = 0;
	        waku_y[11] = yp;
	        waku_z[11] = zp;

	        return( 0 );
        }

        //  座標変換マトリックスを求める
        //  clsCbIni      cb_ini_str      (i)	表示用パラメータ及びデータ
        //  double      Tvps[][4];		(o)	座標変換マトリックス
        //  戻り値                      正常=0, エラー=1
        int	get_Tvps( clsCbIni cb_ini_str, double[,] Tvps )
        {
	        int	i, j;
	        double	xf1, yf1, zf1, xa1, ya1, za1,
		        xf, yf, zf, xa, ya, za,
		        rd, r2, r3, vs,
		        sin_a, sin_b, cos_a, cos_b; 
	        double[,]	Tv = new double[4,4];
	        double[,]	Tp = new double[4,4];
	        double[,]	Ts = new double[4,4];
	        double[,]	Tarb = new double[4,4];
	        double[,]	Tr = new double[4,4];
	        double[,]	Ta = new double[4,4];
	        double[,]	Tb = new double[4,4];
	        double[,]	Tw1 = new double[4,4];
	        double[,]	Tw2 = new double[4,4];

        // 初期設定
            rd = System.Math.Sqrt(System.Math.Pow( (double)cb_ini_str.waku_max[0], (double)2.0 )
		                         +System.Math.Pow( (double)cb_ini_str.waku_max[1], (double)2.0 )
		                         +System.Math.Pow( (double)(cb_ini_str.waku_max[2]-cb_ini_str.waku_zmin), (double)2.0 ) );
	        xa1 = (double)cb_ini_str.waku_max[0] / (double)2.0;
	        ya1 = (double)cb_ini_str.waku_max[1] / (double)2.0 ;
	        za1 = (double)(cb_ini_str.waku_max[2]+cb_ini_str.waku_zmin) / (double)2.0;
	        get_eye_cood( xa1, ya1, za1,
		             cb_ini_str.view_xz, cb_ini_str.view_xy,
                     (double)10.0 * rd, out xf1, out yf1, out zf1);
        // Ｔｒ
	        for( i=0; i<4; i++ )
	        {
	            for( j=0; j<4; j++ )		Tr[i, j] = (double)0.0;
	        }
	        Tr[0, 0] = (double)1.0;
	        Tr[1, 2] = (double)1.0;
	        Tr[2, 1] = (double)(-1.0);
	        Tr[3, 3] = (double)1.0;
        // Ｔａ
	        for( i=0; i<4; i++ )
	        {
	            for( j=0; j<4; j++ )
	            {
		            if( i == j )	Ta[i, j] = (double)1.0;
		            else			Ta[i, j] = (double)0.0;
	            }
	        }
	        Ta[3, 0] = (double)(-xa1);
	        Ta[3, 1] = (double)(-ya1);
	        Ta[3, 2] = (double)(-za1);
        // Ｔｂ
	        for( i=0; i<4; i++ )
	        {
	            for( j=0; j<4; j++ )
	            {
		            if( i == j )	Tb[i, j] = (double)1.0;
		            else			Tb[i, j] = (double)0.0;
	            }
	        }
	        Tb[3, 0] = (double)xa1;
	        Tb[3, 1] = (double)ya1;
	        Tb[3, 2] = (double)za1;
	        calc_matr( Ta, 4, 4,Tr, 4, 4, Tw1 );
	        calc_matr( Tw1, 4, 4,Tb, 4, 4, Tarb );
	        xa = xa1*Tarb[0, 0] + ya1*Tarb[1, 0] + za1*Tarb[2, 0] + Tarb[3, 0];
	        ya = xa1*Tarb[0, 1] + ya1*Tarb[1, 1] + za1*Tarb[2, 1] + Tarb[3, 1];
	        za = xa1*Tarb[0, 2] + ya1*Tarb[1, 2] + za1*Tarb[2, 2] + Tarb[3, 2];
	        xf = xf1*Tarb[0, 0] + yf1*Tarb[1, 0] + zf1*Tarb[2, 0] + Tarb[3, 0];
	        yf = xf1*Tarb[0, 1] + yf1*Tarb[1, 1] + zf1*Tarb[2, 1] + Tarb[3, 1];
	        zf = xf1*Tarb[0, 2] + yf1*Tarb[1, 2] + zf1*Tarb[2, 2] + Tarb[3, 2];
	        r2 = System.Math.Sqrt( (xf-xa)*(xf-xa)+(zf-za)*(zf-za) );
            r3 = System.Math.Sqrt((xf - xa) * (xf - xa) + (yf - ya) * (yf - ya) + (zf - za) * (zf - za));
	        if( r2 == (double)0.0 )
	        {
	           cos_a = (double)1.0;
	           sin_a = (double)0.0;
	        }
	        else
	        {
	           cos_a = (zf-za)/r2;
	           sin_a = (xa-xf)/r2;
	        }
	        sin_b = (yf-ya)/r3;
	        cos_b = r2/r3;
        // Ｔｖ
	        Tv[0, 0] = cos_a;
	        Tv[0, 1] = sin_a*sin_b;
	        Tv[0, 2] = sin_a*cos_b;
	        Tv[0, 3] = (double)0.0;
	        Tv[1, 0] = (double)0.0;
	        Tv[1, 1] = cos_b;
	        Tv[1, 2] = -sin_b;
	        Tv[1, 3] = (double)0.0;
	        Tv[2, 0] = sin_a;
	        Tv[2, 1] = -cos_a*sin_b;
	        Tv[2, 2] = -cos_a*cos_b;
	        Tv[2, 3] = (double)0.0;
	        Tv[3, 0] = -xf*cos_a - zf*sin_a;
	        Tv[3, 1] = -(xf*sin_a*sin_b) - yf*cos_b + (zf*cos_a*sin_b);
	        Tv[3, 2] = -xf*sin_a*cos_b + yf*sin_b + zf*cos_a*cos_b;
	        Tv[3, 3] = (double)1.0;
	        Tv[0, 0] = -Tv[0, 0];
	        Tv[1, 0] = -Tv[1, 0];
	        Tv[2, 0] = -Tv[2, 0];
	        Tv[3, 0] = -Tv[3, 0];
        // Ｔｐ
	        Tp[0, 0] = (double)1.0;
	        Tp[0, 1] = (double)0.0;
	        Tp[0, 2] = (double)0.0;
	        Tp[0, 3] = (double)0.0;
	        Tp[1, 0] = (double)0.0;
	        Tp[1, 1] = (double)1.0;
	        Tp[1, 2] = (double)0.0;
	        Tp[1, 3] = (double)0.0;
	        Tp[2, 0] = (double)0.0;
	        Tp[2, 1] = (double)0.0;
	        Tp[2, 2] = (double)( 0.05 );
	        Tp[2, 3] = (double)( 0.05 );
	        Tp[3, 0] = (double)0.0;
	        Tp[3, 1] = (double)0.0;
	        Tp[3, 2] = -rd/(double)10.0;
	        Tp[3, 3] = (double)0.0;
        // Ｔｓ
            vs = System.Math.Min((double)(cb_ini_str.vp_sp.y - cb_ini_str.vp_ep.y) / 2.0,
		           (double)(cb_ini_str.vp_ep.x-cb_ini_str.vp_sp.x)/2.0 );
	        Ts[0, 0] = vs;
	        Ts[0, 1] = (double)0.0;
	        Ts[0, 2] = (double)0.0;
	        Ts[0, 3] = (double)0.0;
	        Ts[1, 0] = (double)0.0;
	        Ts[1, 1] = vs;
	        Ts[1, 2] = (double)0.0;
	        Ts[1, 3] = (double)0.0;
	        Ts[2, 0] = (double)0.0;
	        Ts[2, 1] = (double)0.0;
	        Ts[2, 2] = (double)1.0;
	        Ts[2, 3] = (double)0.0;
	        Ts[3, 0] = (double)(cb_ini_str.vp_ep.x+cb_ini_str.vp_sp.x)/2.0;
	        Ts[3, 1] = (double)(cb_ini_str.vp_ep.y+cb_ini_str.vp_sp.y)/2.0;
	        Ts[3, 2] = (double)0.0;
	        Ts[3, 3] = (double)1.0;
        // Ｔｖｐｓ
	        calc_matr( Ta, 4, 4,Tr, 4, 4, Tw1 );
	        calc_matr( Tw1, 4, 4,Tb, 4, 4, Tarb );
	        calc_matr( Tarb, 4, 4,Tv, 4, 4, Tw1 );
	        calc_matr( Tw1, 4, 4, Tp, 4, 4, Tw2 );
	        calc_matr( Tw2, 4, 4,Ts, 4, 4, Tvps );

	        return( 0 );
        }

        //  点のワールド座標からスクリーン座標への変換
        //  int         xw, yw, zw      (i)	点のワールド座標
        //  double      Tvps[][4];		(i)	座標変換マトリックス
        //  int[]       xs, ys		    (o)	スクリーン座標
        //  戻り値                      正常=0, エラー=1
        int	pnt_to_scrn( int xw, int yw, int zw, double[,] T, out int xs, out int ys )
        {
	        double	x, y, w;


	        x = (double)xw*T[0, 0]+(double)yw*T[1, 0]
			              +(double)zw*T[2, 0]+T[3, 0];
	        y = (double)xw*T[0, 1]+(double)yw*T[1, 1]
			              +(double)zw*T[2, 1]+T[3, 1];
	        w = (double)xw*T[0, 3]+(double)yw*T[1, 3]
			              +(double)zw*T[2, 3]+T[3, 3];
	        xs = do_round(x/w);
	        ys = do_round(y/w);

	        return( 0 );
        }

        //  直線の傾きによる文字の表示
        //  int         x1, y1, x2, y2  (i)	直線の端点座標
        //  string      str;		    (i)	表示する文字
        //  int         color		    (i)	文字の色
        //  戻り値                      正常=0, エラー=1
        int	draw_text( int x1, int y1, int x2, int y2, string text, int color )
        {
	        int		    text_x, text_y, i;
	        double		t_alf;
            char[]      str;

            str = text.ToCharArray();
            lpView._settextcolor( color );
        // 表示位置の決定
	        t_alf = set_text_pos( x1, y1, x2, y2, str, out text_x, out text_y );
        // 表示
	        i = 0;
            for( i = 0 ; i < str.Length ; i ++ )
            {
               lpView._gputchar(text_x + 4, text_y, str[i]);

               if (System.Math.Abs(t_alf) <= (double)1.00)
	           {
		            text_x = text_x + ( 16+clsCom.TEXT_TEXT_D );
                    text_y = text_y - do_round((double)(16 + clsCom.TEXT_TEXT_D) * t_alf);
	           }
	           else
	           {
                    text_y = text_y + (16 + clsCom.TEXT_TEXT_D);
		            if( t_alf > (double)0.0001 )
		                text_x = text_x -
                        do_round((double)(16 + clsCom.TEXT_TEXT_D) / System.Math.Abs(t_alf));
		            else
		                text_x = text_x +
                        do_round((double)(16 + clsCom.TEXT_TEXT_D) / System.Math.Abs(t_alf));
	            }
	        }

	        return( 0 );
        }

        //  文字の表示位置の決定
        //  int         x1, y1, x2, y2  (i)	直線の端点座標
        //  string      str;		    (i)	表示する文字
        //  int[]       xo, yo		    (o)	表示位置の座標
        //  戻り値                      線の傾き  tan(ang)
        double set_text_pos(int x1, int y1, int x2, int y2, char[] str, out int xo, out int yo)
        {
	        int	n, sx1, sy1, sx2, sy2;
	        double	s_alf, c_alf, t_alf, a, b, r;


        // 初期設定
	        if ( x1 > x2 )
	        {
	           sx1 = x1;
	           sy1 = y1;
	           x1 = x2;
	           y1 = y2;
	           x2 = sx1;
	           y2 = sy1;
	        }

	        n = 0;
        //文字を表示するための基準線の端点座標（sx, sy）
	        a = (double)( y1 - y2 ) + (double)0.0001;
	        b = (double)( x2 - x1 ) + (double)0.0001;
	        r = System.Math.Sqrt( a * a + b * b );
	        s_alf = a / r;
	        c_alf = b / r;
	        t_alf = a / b;
	        sx1 = x1 + do_round( (double)clsCom.TEXT_LINE_D * s_alf );
            sy1 = y1 + do_round( (double)clsCom.TEXT_LINE_D * c_alf);
            sx2 = x2 + do_round( (double)clsCom.TEXT_LINE_D * s_alf);
            sy2 = y2 + do_round( (double)clsCom.TEXT_LINE_D * c_alf);
	        if ( System.Math.Abs( t_alf ) < (double)1.00 )
	        {
	           if ( t_alf > (double)0.00 )
	           {
                   xo = (sx1 + sx2) / 2 - (n / 2) * (16 + clsCom.TEXT_TEXT_D);
	   	           yo = sy1 - do_round( (double)( xo-sx1 )*t_alf );
	           }
	           else
	           {
                   xo = (sx1 + sx2) / 2 - (n / 2) * (16 + clsCom.TEXT_TEXT_D);
	   	           yo = sy1 - do_round( (double)( xo-sx1 )*t_alf );
                   yo = yo - do_round((double)(16 + clsCom.TEXT_TEXT_D) * t_alf);
	           }
	        }
	        else
	        {
	           if( t_alf > (double)0.0001 )
	           {
                    yo = (sy1 + sy2) / 2 - (n / 2) * (16 + clsCom.TEXT_TEXT_D);
	   	            xo = sx1 + do_round( (double)( sy1-yo )/t_alf );
	           }
	           else
	           {
                    yo = (sy1 + sy2) / 2 - (n / 2) * (16 + clsCom.TEXT_TEXT_D);
	   	            xo = sx1 + do_round( (double)( sy1-yo )/t_alf );
                    yo = yo - do_round((double)(16 + clsCom.TEXT_TEXT_D) * c_alf * s_alf);
                    xo = xo - do_round((double)(16 + clsCom.TEXT_TEXT_D) * s_alf * s_alf);
	           }
	        }

	        return( t_alf );
        }


        //  二つのマトリックスの積
        // double	*matr_a;		//(i)	マトリックスＡ
        // int	    row_a;			//(i)	Ａの行数
        // int	    colu_a;			//(i)	Ａの列数
        // double	*matr_b;		//(i)	マトリックスＢ
        // int	    row_b;			//(i)	Ｂの行数
        // int	    colu_b;			//(i)	Ｂの列数
        // double	*matr_c;		//(o)	Ｃ＝Ａ＊Ｂ
        //  戻り値                      正常=0, エラー=1
        int	calc_matr( double[,] matr_a, int row_a, int colu_a, double[,]matr_b, int row_b, int colu_b, double[,] matr_c )
        {
	        int	i, j, k;

	        if( colu_a != row_b )		return( 1 );
	        for( i=0; i<row_a; i++ )
	        {
	            for( j=0; j<colu_b; j++ )
	            {
                    matr_c[i, j] = (double)0.0;
                    for (k = 0; k < colu_a; k++)
		            {
                        matr_c[i, j] = matr_c[i, j] + matr_a[i, k] * matr_b[k, j];
                    }
	            }
	        }

	        return( 0 );
        }

        //  視点座標を求める
        //  double	xa, ya, za;		//(i)	注視点座標
        //  int	ang_xz, ang_xy;		//(i)	視線偏角
        //  double	len;			//(i)	注視点から視点までの長さ
        //  double	*xf, *yf, *zf;	//(o)	視点座標
        //  戻り値                      正常=0, エラー=1
        int get_eye_cood(double xa, double ya, double za, int ang_xz, int ang_xy, double len, out double xf, out double yf, out double zf)
        {
	        double	ang_a, ang_b, cos_alf, sin_alf, cos_beta, sin_beta,
		        p, q, k;

        // 方程式 ( XF=XA+PT, YF=YA+QT,	ZF=ZA+KT )
	        ang_b = (double)ang_xz / (double)180.0 * System.Math.PI;
            ang_a = (double)ang_xy / (double)180.0 * System.Math.PI;
            cos_alf = System.Math.Cos(ang_a);
            sin_alf = System.Math.Sin(ang_a);
            cos_beta = System.Math.Cos(ang_b);
            sin_beta = System.Math.Sin(ang_b);
	        p = cos_beta * sin_alf;
	        q = cos_beta * cos_alf;
	        k = sin_beta;
	        xf = xa - p * len;
	        yf = ya - q * len;
	        zf = za + k * len;

	        return( 0 );
        }


        //  直線とＺ＝０平面の交点座標を求める
        //  int	x1, y1, z1, x2, y2, z2;		//(i)	直線の端点座標
        //  int	*xo, *yo, *zo;			    //(o)	直線とＺ＝０平面の交点座標
        //  戻り値                      正常=0, エラー=1
        int get_xyz_o(int x1, int y1, int z1, int x2, int y2, int z2, out int xo, out int yo, out int zo)
        {
	        float	h;

            xo = 0;
            yo = 0;
            zo = 0;
	        if ( z1 == z2 )		return( 1 );
	        h = (float)z1/(float)( z1-z2 );
	        xo = x1 + do_round( (float)(x2-x1)*h );
	        yo = y1 + do_round( (float)(y2-y1)*h );
	        zo = 0;

	        return( 0 );
        }

        //  ラインを描く
        //  int		x1, y1;		        //(i)	始点座標
        //  int		x2, y2;		        //(i)	終点座標
        //  unsigned short	color;		//(i)	色
        //  unsigned short	style;		//(i)	線種
        //  戻り値                      正常=0, エラー=1
        int	draw_line( int x1, int y1, int x2, int y2, int color, int style )
        {
            lpView._setcolor(color);
            lpView._setlinestyle(style);
            lpView._moveto(x1, y1);
            lpView._lineto(x2, y2);

	        return( 0 );
        }

        //  実数の四捨五入
        //  double	x;		//(i)	四捨五入する実数
        //  戻り値                  四捨五入した整数値
        int	do_round( double x )
        {
	        if( (x)-(int)(x) < (double)0.5 )	return( (int)(x) );
	        else					return( (int)(x)+1 );
        }

	}
}

