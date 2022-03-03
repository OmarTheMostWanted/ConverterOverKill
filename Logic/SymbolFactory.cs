using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace RomanConverter.Logic;

public class SymbolFactory
{

    
    
    private Dictionary<char , AbstractSymbol> _cache = new();

    public Dictionary<char, AbstractSymbol> GenerateAllSymbols()
    {

        int[] vals = new[] {1, 5, 10, 50 ,100, 500, 1000};
        char[] symboles = new[] {'I', 'V', 'X', 'L', 'C', 'D', 'M'};
        
        for (var i = 0; i < symboles.Length; i++)
        {
            _cache.Add(symboles[i] , CreateSymbol(symboles[i] , vals[i]));
        }

        return _cache;
    }
    
    public Dictionary<int, AbstractSymbol> GenerateAllNumbers()
    {

        var res = new Dictionary<int, AbstractSymbol>();
        
        int[] vals = new[] {1, 5, 10, 50 ,100, 500, 1000};
        char[] symboles = new[] {'I', 'V', 'X', 'L', 'C', 'D', 'M'};
        
        for (var i = 0; i < symboles.Length; i++)
        {
            res.Add(vals[i] , CreateSymbol(symboles[i] , vals[i]));
        }

        return res;
    }

    public AbstractSymbol CreateSymbol(char type , int val)
    {
        // AppDomain domain = Thread.GetDomain();
        
        AssemblyName assemblyName = new AssemblyName("Symbol");
        
        AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName , AssemblyBuilderAccess.Run);

        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName.Name);


        StringBuilder stringBuilder = new StringBuilder("dynamic_symbol_type_").Append(type);

        TypeBuilder typeBuilder =
            moduleBuilder.DefineType(stringBuilder.ToString(), TypeAttributes.Public, typeof(AbstractSymbol));

        // FieldBuilder fieldBuilder = typeBuilder.DefineField("time_created", typeof(DateTime), FieldAttributes.Public);

        
        
        
        
        // ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public,
        //     CallingConventions.Standard, constructorArgumentsTypes);
        //
        // ILGenerator ilGenerator = constructorBuilder.GetILGenerator();
        //
        // ilGenerator.Emit(OpCodes.Ldarg_0);
        // ilGenerator.Emit(OpCodes.Call , typeof(object).GetConstructor(Type.EmptyTypes));
        //
        // ilGenerator.Emit(OpCodes.Ldarg_0);
        // ilGenerator.Emit(OpCodes.Ldarg_1);
        // ilGenerator.Emit(OpCodes.Stfld, fieldBuilder);
        // ilGenerator.Emit(OpCodes.Ret);

        // Type objectType = Type.GetType("System.Object");
        // ConstructorInfo objectCtor = objectType.GetConstructor(new Type[0]);
        Type[] constructorArgumentsTypes = new Type[] {typeof(int), typeof(char)};

        ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard,constructorArgumentsTypes );

        ILGenerator ctorIL = constructorBuilder.GetILGenerator();

        // ctorIL.Emit(OpCodes.Ldarg_0);
        // ctorIL.Emit(OpCodes.Call , objectCtor);
        //
        // ctorIL.Emit(OpCodes.Ldarg_0);
        // ctorIL.Emit(OpCodes.Ldarg_1);
        // ctorIL.Emit(OpCodes.Stfld, type);
        //
        // ctorIL.Emit(OpCodes.Ldarg_0);
        // ctorIL.Emit(OpCodes.Ldarg_2);
        // ctorIL.Emit(OpCodes.Stfld , val);
        //
        // ctorIL.Emit(OpCodes.Ret);

        var setV = typeof(AbstractSymbol).GetProperty(nameof(AbstractSymbol.Val))!.SetMethod!;
        var setS = typeof(AbstractSymbol).GetProperty(nameof(AbstractSymbol.S))!.SetMethod!;

        ctorIL.Emit(OpCodes.Ldarg_0);
        ctorIL.Emit(OpCodes.Ldarg_1);
        ctorIL.Emit(OpCodes.Call, setV);
        
        ctorIL.Emit(OpCodes.Ldarg_0);
        ctorIL.Emit(OpCodes.Ldarg_2);
        ctorIL.Emit(OpCodes.Call, setS);

        ctorIL.Emit(OpCodes.Ret);
        
        Type dynamicType = typeBuilder.CreateType()!;
        var properties = dynamicType.GetProperties();
        AbstractSymbol dynamic_instance =
            (AbstractSymbol) Activator.CreateInstance(dynamicType, new object[] { val, type});

        // dynamic_instance.S = type;
        // dynamic_instance.Val = val;

        return dynamic_instance;


        // if (type.IsAssignableFrom(typeof(AbstractSymbol)))
        // {
        //     var instance = (AbstractSymbol) Activator.CreateInstance(type , BindingFlags.Public );
        // }
    }
    
    
}