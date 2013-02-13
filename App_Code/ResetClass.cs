using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceLayer
{
    class ResetClass
    {
        public void ResetFinally(params Object[] listParam)
        {
            for (int i = 0; i < listParam.Length; i++)
            {
                listParam[0] = null;
            }
        }
    }
}
