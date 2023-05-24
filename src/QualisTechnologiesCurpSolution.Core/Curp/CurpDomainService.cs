using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using Abp.Domain.Services;
using QualisTechnologiesCurpSolution.Curp.ValueObjects;

namespace QualisTechnologiesCurpSolution.Curp
{
    public class CurpDomainService : DomainService, ICurpDomainService
    {
        public IEnumerable<string> Validar(Person person)
        {
            var results = new List<string>();

            var resultVaidarEstructura = ValidarEstructura(person.Curp.ToUpper());
            if (!string.IsNullOrEmpty(resultVaidarEstructura))
                results.Add(resultVaidarEstructura);

            var resultValidarDigito = ValidarDigitoVerificador(person.Curp.ToUpper());
            if (!string.IsNullOrEmpty(resultValidarDigito))
                results.Add(resultValidarDigito);

            var resultValidarNombres = ValidarNombres(
                person.Curp.ToUpper(), person.Nombres.ToUpper(), person.ApellidoPaterno.ToUpper(), person.ApellidoMaterno.ToUpper());
            if (!string.IsNullOrEmpty(resultValidarNombres))
                results.Add(resultValidarNombres);

            var resultValidarFecha = ValidarFecha(person.Curp.ToUpper(), person.FechaNacimiento);
            if (!string.IsNullOrEmpty(resultValidarFecha))
                results.Add(resultValidarFecha);

            return results;
        }

        private string ValidarEstructura(string curp)
        {
            var result = "";

            var re = @"^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$";
            Regex rx = new Regex(re, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var validado = rx.IsMatch(curp);

            if (!validado)
                result = "El formato del CURP es incorrecto, favor de validar.";

            return result;
        }

        public string ValidarDigitoVerificador(string curp)
        {
            var result = "";

            var diccionario = "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
            var suma = 0.0;
            var digito = 0.0;

            for (var i = 0; i < 17; i++)
                suma = suma + diccionario.IndexOf(curp[i]) * (18 - i);

            digito = 10 - suma % 10;

            if (digito == 10) digito = 0;

            if (!curp.EndsWith(digito.ToString()))
                result = "El digito verificador es incorrecto, favor de verificarlo.";

            return result;
        }

        public string ValidarNombres(string curp, string nombres, string aPaterno, string aMaterno)
        {
            var result = "";
            var vocales = new List<char>() { 'A', 'E', 'I', '0', 'U' };
            var paterno = aPaterno.Substring(0, 1);

            aPaterno = aPaterno.Substring(1, aPaterno.Length - 1);

            foreach (var letra in aPaterno)
            {
                if (vocales.Contains(letra))
                {
                    paterno = paterno + letra;
                    break;
                }
            }

            var bloque = $"{paterno}{aMaterno.Substring(0, 1)}{nombres.Substring(0, 1)}";

            if (!bloque.Equals(curp.Substring(0, 4)))
                result = "Los nombres o apellidos no corresponden a la estructura del CURP, favor de verificarlo.";

            return result;
        }

        public string ValidarFecha(string curp, string fecha)
        {
            var result = "";

            try
            {
                var fechaReal = Convert.ToDateTime(fecha).ToString("yy/MM/dd").Replace("/", "");

                if (!curp.Substring(4, 6).Equals(fechaReal))
                    result = "La fecha de nacimiento no corresponde a la estructura del CURP, favor de verificarlo.";
            }
            catch (Exception error)
            {
                result = $"La fecha de nacimiento no corresponde a la estructura del CURP - {error.Message} -, favor de verificarlo.";
            }

            return result;
        }
    }
}

