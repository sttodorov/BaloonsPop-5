using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaloonsPopGame
{
    interface IFrontEnd
    {
        public string UserCommandAsScript();

        public void RenderGameFieldState();

        public void PublishPrompt();


    }
}
