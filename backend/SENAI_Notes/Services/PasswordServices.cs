using Microsoft.AspNetCore.Identity;

namespace SENAI_Notes.Services
{
    //public class PasswordService
    //{
    //    public class PasswordService
    //    {
    //        //PasswordHasher ==> algoritmo PBKDF2 - Password-Based Key Derivation Function 2
    //        private readonly PasswordHasher<Cliente> _hasher = new();   //classe que contem a senha a criptografar
    //                                                                    //private readonly PasswordHasher<Cliente> _hasher = new PasswordHasher<Cliente>();   identica a linha de cima


    //        //1 - Gerar um Hash
    //        public string HashPassword(Cliente cliente)
    //        {
    //            return _hasher.HashPassword(cliente, cliente.Senha);
    //        }

    //        //2 - Verificar o Hash
    //        public bool VerificarSenha(Cliente cliente, string senhaInformada)
    //        {

    //            var resultado = _hasher.VerifyHashedPassword(cliente, cliente.Senha, senhaInformada);
    //            return resultado == PasswordVerificationResult.Success;

    //        }

    //    }
    }