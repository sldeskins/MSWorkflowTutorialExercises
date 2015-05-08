using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCommom//WebTearWorkflow
{
  public  class PageFinishedEventArgs
    {
      private string pageData;
      public string Data
      {
          get
          {
              return this.pageData;
          }
      }
      public PageFinishedEventArgs (string data)
      {
          this.pageData = data;
      }
    }
}
