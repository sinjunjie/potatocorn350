using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWEN_Delonix_Regia_HMS
{
    class HitBox
    {
        Rectangle rect = new Rectangle();

        public object Tag { get; set; }

        public HitBox(Rectangle _rect)
        {
            rect = _rect;
        }

        public bool Hit(Point point)
        {
            if (rect.Contains(point))
            {
                return true;
            }
            return false;
        }
    }
}
