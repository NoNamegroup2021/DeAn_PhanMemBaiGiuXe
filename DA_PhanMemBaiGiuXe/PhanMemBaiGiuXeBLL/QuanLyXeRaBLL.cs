﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMemBaiGiuXeDAL;

namespace PhanMemBaiGiuXeBLL
{
    public class QuanLyXeRaBLL
    {
        QuanLyXeRaDAL QLXR = new QuanLyXeRaDAL();
        public QuanLyXeRaBLL()
        {

        }

        public bool ktTheXe(string mathe, string bienso)
        {
            return QLXR.ktTheXe(mathe, bienso);
        }

        public bool SuaLoaiGiaoTac(string mathe, DateTime thoigian, string tentk)
        {
            return QLXR.SuaLoaiGiaoTac(mathe, thoigian, tentk);
        }
    }
}