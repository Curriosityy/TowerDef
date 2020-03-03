using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface ISubject
{

    void Attach(IObserver subject);
    void Detach(IObserver subject);
    void Notify();
}

