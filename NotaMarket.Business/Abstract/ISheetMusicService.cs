﻿using NotaMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaMarket.Business.Abstract
{
    public interface ISheetMusicService
    {
        List<SheetMusic> GetSheetMusics();
        void CreateSheetMusic(SheetMusic sheetMusic);
    }
}
