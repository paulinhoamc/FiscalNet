﻿using FiscalNET.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalNet.Implementacoes.Icms
{
    class Icms20 : IIcms
    {
        private decimal AliqIcmsProprio { get; set; }
        private decimal AliqRedBcIcms { get; set; }
        private decimal ValorIpi { get; set; }
        private decimal DespesasAcessorias { get; set; }
        private decimal ValorFrete { get; set; }
        private decimal ValorProduto { get; set; }
        private decimal ValorSeguro { get; set; }

        public Icms20(decimal aliqIcmsProprio, decimal aliqRedBcIcms,
            decimal valorIpi, decimal despesasAcessorias,
            decimal valorFrete, decimal valorProduto,
            decimal valorSeguro)
        {
            this.AliqIcmsProprio    = aliqIcmsProprio;
            this.AliqRedBcIcms      = aliqRedBcIcms; 
            this.ValorIpi           = valorIpi;
            this.DespesasAcessorias = despesasAcessorias;
            this.ValorFrete         = valorFrete;
            this.ValorProduto       = valorProduto;
            this.ValorSeguro        = valorSeguro;
        }

        public bool PossuiIcmsProprio
        {
            get
            {
                return true;
            }
        }

        public bool PossuiIcmsST
        {
            get
            {
                return false;
            }
        }

        public bool PossuiRedBCIcmsProprio
        {
            get
            {
                return true;
            }
        }

        public bool PossuiRedBCIcmsST
        {
            get
            {
                return false;
            }
        }

        public decimal BaseIcms()
        {        
            return new BaseIcms(ValorIpi, DespesasAcessorias, ValorFrete, ValorProduto, ValorSeguro).GerarBaseIcms();
        }

        public decimal ValorIcms()
        {
            BaseIcms vBcIcms    = new BaseIcms(ValorIpi, DespesasAcessorias, ValorFrete, ValorProduto, ValorSeguro);

            decimal vRedBcIcms  = vBcIcms.GerarBaseIcms() * (AliqRedBcIcms / 100);

            ValorIcms valorIcms = new ValorIcms(AliqIcmsProprio, ValorIpi, DespesasAcessorias, ValorFrete, ValorProduto, ValorSeguro);

            return (valorIcms.GerarValorIcms() * (AliqRedBcIcms / 100));
        }

        public decimal BaseIcmsST()
        {
            throw new NotImplementedException();
        }

        public decimal PercRedBaseIcms()
        {
            throw new NotImplementedException();
        }

        public decimal PercRedBaseIcmsST()
        {
            throw new NotImplementedException();
        }        

        public decimal ValorIcmsST()
        {
            throw new NotImplementedException();
        }

        public decimal ValorRedBaseIcms()
        {
            throw new NotImplementedException();
        }

        public decimal ValorRedBaseIcmsST()
        {
            throw new NotImplementedException();
        }
    }
}