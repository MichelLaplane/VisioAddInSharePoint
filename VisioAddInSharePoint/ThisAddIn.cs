﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Visio = Microsoft.Office.Interop.Visio;
using Office = Microsoft.Office.Core;

namespace VisioAddInSharePoint
{
    public partial class ThisAddIn
    {
    static internal Ribbon ribbonApplication;
    private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

    #endregion
    #region vsto ribbon support

    /// <summary>
    /// Fourni l'objet Ribbon de l'application au chargement de Visio
    /// </summary>
    /// <returns></returns>
    protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
      {
      ThisAddIn.ribbonApplication = new Ribbon();
      return ThisAddIn.ribbonApplication;
      }


    #endregion

    }
  }
