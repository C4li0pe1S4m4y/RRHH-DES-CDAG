// <copyright file="PlanOperativoTest.cs">Copyright ©  2015</copyright>
using System;
using AplicacionSIPA1.Operativa;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AplicacionSIPA1.Operativa.Tests
{
    /// <summary>Esta clase contiene pruebas unitarias parametrizadas para PlanOperativo</summary>
    [PexClass(typeof(PlanOperativo))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class PlanOperativoTest
    {
        /// <summary>Código auxiliar de prueba para validarControlesABC()</summary>
        [PexMethod]
        public bool validarControlesABCTest([PexAssumeUnderTest]PlanOperativo target)
        {
            bool result = target.validarControlesABC();
            return result;
            // TODO: agregar aserciones a método PlanOperativoTest.validarControlesABCTest(PlanOperativo)
        }
    }
}
