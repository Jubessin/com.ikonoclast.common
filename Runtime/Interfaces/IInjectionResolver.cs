using System.Collections;

namespace Ikonoclast.Common
{
    public interface IInjectionResolver
    {
        void Resolve(in IEnumerable injections);
    }
}
