using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace RomanConverter.Logic;

public class SymbolFactory
{

    private Dictionary<char , AbstractSymbol> _cache = new();


    public AbstractSymbol CreateSymbol(char type , int val)
    {
        
        AssemblyName assemblyName = new AssemblyName("Symbol");
        
        AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName , AssemblyBuilderAccess.Run);

        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName.Name);


        StringBuilder stringBuilder = new StringBuilder("dynamic_symbol_type_").Append(type);

        TypeBuilder typeBuilder =
            moduleBuilder.DefineType(stringBuilder.ToString(), TypeAttributes.Public, typeof(AbstractSymbol));

        FieldBuilder fieldBuilder = typeBuilder.DefineField("time_created", typeof(DateTime), FieldAttributes.Public);

        Type[] constructorArgumentsTypes = new Type[] {typeof(int), typeof(char)};

        ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public,
            CallingConventions.Standard, constructorArgumentsTypes);

        ILGenerator ilGenerator = constructorBuilder.GetILGenerator();
        
        ilGenerator.Emit(OpCodes.Ldarg_0);
        ilGenerator.Emit(OpCodes.Call , typeof(object).GetConstructor(Type.EmptyTypes));
        
        ilGenerator.Emit(OpCodes.Ldarg_0);
        ilGenerator.Emit(OpCodes.Ldarg_1);
        ilGenerator.Emit(OpCodes.Stfld, fieldBuilder);
        ilGenerator.Emit(OpCodes.Ret);
        
        
        Type dynamicType = typeBuilder.CreateType();

        AbstractSymbol dynamic_instance =
            (AbstractSymbol) Activator.CreateInstance(dynamicType, BindingFlags.Public, new object[] {type , val});

        // dynamic_instance.S = type;
        // dynamic_instance.Val = val;

        return dynamic_instance;


        // if (type.IsAssignableFrom(typeof(AbstractSymbol)))
        // {
        //     var instance = (AbstractSymbol) Activator.CreateInstance(type , BindingFlags.Public );
        // }
    }
    
    
}