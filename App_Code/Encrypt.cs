using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.IO;

/// <summary>
/// SymmCrypto is a wrapper of System.Security.Cryptography.SymmetricAlgorithm classes
/// and simplifies the interface. It supports customized SymmetricAlgorithm as well.
/// </summary>
public class Encrypt
{
    /// <remarks>
    /// Supported .Net intrinsic SymmetricAlgorithm classes.
    /// </remarks>

    public string Encrypting(string PlainText, string strKey24)
    {
        TripleDESCryptoServiceProvider crp = new TripleDESCryptoServiceProvider();
        UnicodeEncoding uencode = new UnicodeEncoding();
        ASCIIEncoding aencode = new ASCIIEncoding();
        //Store plain text as  a byte array
        byte[] bytPlainText = uencode.GetBytes(PlainText);
        //Create a memory stream for holding encrypted text
        MemoryStream stmCipherText = new MemoryStream();
        //Private key
        byte[] slt = System.Text.ASCIIEncoding.ASCII.GetBytes("0");
        PasswordDeriveBytes pdb = new PasswordDeriveBytes(strKey24, slt);
        byte[] bytDerivedKey = pdb.GetBytes(24);
        crp.Key = bytDerivedKey;
        //Initialization vector is the encryption seed
        crp.IV = pdb.GetBytes(8);
        //Create a crypto-writer to encrypt a bytearray inta a stream
        CryptoStream csEncrypted = new CryptoStream(stmCipherText, crp.CreateEncryptor(), CryptoStreamMode.Write);
        csEncrypted.Write(bytPlainText, 0, bytPlainText.Length);
        csEncrypted.FlushFinalBlock();
        //return result as a base64 encoded string
        return Convert.ToBase64String(stmCipherText.ToArray());

    }

    public string Decrypting(string strCiperText, string strKey24)
    {
        TripleDESCryptoServiceProvider crp = new TripleDESCryptoServiceProvider();
        UnicodeEncoding uencode = new UnicodeEncoding();
        ASCIIEncoding aencode = new ASCIIEncoding();
        //Store cipher text as  a byte array
        byte[] bytCipherText = Convert.FromBase64String(strCiperText);

        MemoryStream stmPlainText = new MemoryStream();
        MemoryStream stmCipherText = new MemoryStream(bytCipherText);
        //Private Key
        byte[] slt = System.Text.ASCIIEncoding.ASCII.GetBytes("0");
        PasswordDeriveBytes pdb = new PasswordDeriveBytes(strKey24, slt);
        byte[] bytDerivedKey = pdb.GetBytes(24);
        crp.Key = bytDerivedKey;
        //Initialization vector 
        crp.IV = pdb.GetBytes(8);
        //Create a crypto stream decoder to decode a cipher text stream int aplain text stream
        CryptoStream csDecrypted = new CryptoStream(stmCipherText, crp.CreateDecryptor(), CryptoStreamMode.Read);
        StreamWriter sw = new StreamWriter(stmPlainText);
        StreamReader sr = new StreamReader(csDecrypted);
        sw.Write(sr.ReadToEnd());
        //Clean up afterwards
        sw.Flush();
        csDecrypted.Clear();
        crp.Clear();

        return uencode.GetString(stmPlainText.ToArray());
    }
}
