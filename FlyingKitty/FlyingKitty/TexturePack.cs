using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingKitty
{

    static class TexturePack
    {
        static public readonly Uri PlayerTexture = new Uri("../../media/kitty.png", UriKind.Relative);
        static public readonly Uri PlayerSkinTexture = new Uri("../../media/boll.png", UriKind.Relative);
        static public readonly Uri TubeTexture = new Uri("../../media/obstacle.png", UriKind.Relative);
        static public readonly Uri FinishTexture = new Uri("../../media/finish.jpg", UriKind.Relative);
        static public readonly Uri SkyTexture = new Uri("../../media/sky.jpg", UriKind.Relative);
        static public readonly Uri GroundTexture = new Uri("../../media/graund.jpg", UriKind.Relative);
    }
}
