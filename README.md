# Equals-GetHashCode-Interfaces-Comparacao
Equals, GetHashCode, IEquatable&lt;T>, IEqualityComparer&lt;T>, IComparable&lt;T> e IComparer&lt;T>

```c#
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace IgualdadeObjetos
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }

        /// <summary>
        /// Define se o objeto é igual
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is Pessoa pessoa)
                return CPF.Equals(pessoa.CPF);

            return false;
        }

        /// <summary>
        /// Algumas construções fazem o teste do HashCode para depois chamar o Equals
        /// if (a.GetHashCode() == b.GetHashCode()) 
        ///     if (a.Equals(b))
        /// </summary>
        public override int GetHashCode()
        {
            return CPF.GetHashCode();
        }
    }

    /// <summary>
    /// IEquatable<T> = Usado para fornecer um metodo seguro para Equals
    /// IComparable<T> = Usado para ordenação e comparação de objetos
    /// </summary>
    public class Funcionario : Pessoa, IEquatable<Funcionario>, IComparable<Funcionario>
    {
        public int CompareTo([AllowNull] Funcionario other)
        {
            return this.CPF.CompareTo(other.CPF);
        }

        public bool Equals([AllowNull] Funcionario other)
        {
            return this.CPF.Equals(other?.CPF);
        } 
    }

    /// <summary>
    /// Regra pode ser usada para comparar um determinado objeto 
    /// </summary>
    public class FuncionarioIdEqual : IEqualityComparer<Funcionario>
    {
        public bool Equals([AllowNull] Funcionario x, [AllowNull] Funcionario y)
        {
            return x.Id.Equals(y.Id);
        }

        public int GetHashCode([DisallowNull] Funcionario obj)
        {
            return obj.Id.GetHashCode();
        }
    }

    /// <summary>
    /// IComparer<T> usado para criar uma regra de comparação entre objetos, essa regra pode ser usada no metodo Sort de uma lista
    /// </summary>
    public class FunctionarioIdComparer : IComparer<Funcionario>
    {
        public int Compare([AllowNull] Funcionario x, [AllowNull] Funcionario y)
        {
            return x.Id.CompareTo(y.Id);
        }
    }
}
```
