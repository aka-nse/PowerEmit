using System.Reflection;

namespace PowerEmit.Disassemblers;

partial class ILDisassembler
{
    partial class Entity
    {
        private void DisassembleNextJmp()
        {
            var callable = Module.ResolveMethod(ReadStreamHead<int>());
            if(callable is not MethodInfo meth)
            {
                throw new InvalidOperationException();
            }
            PushOperation(Inst.Jmp(meth));
        }

        private void DisassembleNextCall()
        {
            var callable = Module.ResolveMethod(ReadStreamHead<int>());
            switch(callable)
            {
            case MethodInfo meth:
                PushOperation(Inst.Call(meth));
                break;
            case ConstructorInfo ctor:
                PushOperation(Inst.Call(ctor));
                break;
            default:
                throw new InvalidOperationException();
            }
        }

        private void DisassembleNextCallvirt()
        {
            var callable = Module.ResolveMethod(ReadStreamHead<int>());
            if(callable is not MethodInfo meth)
            {
                throw new InvalidOperationException();
            }
            PushOperation(Inst.Callvirt(meth));
        }

        private void DisassembleNextNewobj()
        {
            var callable = Module.ResolveMethod(ReadStreamHead<int>());
            if(callable is not ConstructorInfo ctor)
            {
                throw new InvalidOperationException();
            }
            PushOperation(Inst.Newobj(ctor));
        }

        private void DisassembleNextLdftn()
        {
            var callable = Module.ResolveMethod(ReadStreamHead<int>());
            if(callable is not MethodInfo meth)
            {
                throw new InvalidOperationException();
            }
            PushOperation(Inst.Ldftn(meth));
        }

        private void DisassembleNextLdvirtftn()
        {
            var callable = Module.ResolveMethod(ReadStreamHead<int>());
            if(callable is not MethodInfo meth)
            {
                throw new InvalidOperationException();
            }
            PushOperation(Inst.Ldvirtftn(meth));
        }
    }
}
