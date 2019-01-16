using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SJKP.ARMTools.Test
{
    [TestClass]
    public class MakeParameterFileTest
    {
        [TestMethod]
        [DeploymentItem("azuredeploy.json")]
        public void MakeParameterFile()
        {
            var res = MakeParameterFileOptions.Execute(new MakeParameterFileOptions()
            {
                template = "azuredeploy.json",
                outfile = "parameters.json"
            });

            Assert.AreEqual(0, res);
        }
    }
}
