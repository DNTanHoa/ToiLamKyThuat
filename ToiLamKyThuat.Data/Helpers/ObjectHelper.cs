using System;
using System.Collections.Generic;
using System.Text;
using ToiLamKyThuat.Data.Enums;
using ToiLamKyThuat.Data.Models;

namespace ToiLamKyThuat.Data.Helpers
{
    public static class ObjectHelper
    {
        public static T Initialization<T>(this T model, InitType type, int initUser) where T : BaseModel
        {
            model.UpdateDate = AppGlobal.InitDateTime;
            model.UpdateUser = initUser;
            switch (type)
            {
                case InitType.Update:
                    break;
                case InitType.Insert:
                    model.CreateDate = AppGlobal.InitDateTime;
                    model.CreateUser = initUser;
                    break;
            }
            return model;
        }
    }
}
