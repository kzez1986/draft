using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimorfizm
{
    interface IDrawToForm
    {
        void Draw();
    }

    public interface IDrawToMemory
    {
        void Draw();
    }

    public interface IDrawToPrinter
    {
        void Draw();
    }

    class Octagon : IDrawToForm, IDrawToMemory, IDrawToPrinter //jawna implementacja interfejsu
    {

        void IDrawToForm.Draw()
        {
            throw new NotImplementedException();
        }

        void IDrawToMemory.Draw()
        {
            throw new NotImplementedException();
        }

        void IDrawToPrinter.Draw()
        {
            throw new NotImplementedException();
        }
    }
}
