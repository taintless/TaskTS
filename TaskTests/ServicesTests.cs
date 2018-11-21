using System;
using System.Security.Authentication;
using Task;
using Xunit;

namespace TaskTests
{
    public class ServicesTests
    {
        [Fact]
        public void FormatWrappedString_ValidInput_Success()
        {
            var modelToTest = new FileInfoModel
            {
                SymbolsCount = 7,
                Text = "ðiuolaikiðkas ir mano þodis"
            };
            var actual = Services.FormatWrappedString(modelToTest);

            Assert.Equal("ðiuolai\r\nkiðkas\r\nir mano\r\nþodis\r\n", actual);
        }

        [Fact]
        public void StringToCount_NegativeValue_ThrowException()
        {
            const string negativeInput = "-2";
            
            Exception ex = Assert.Throws<ApplicationException>(() => Services.StringToCount(negativeInput));

            Assert.Equal("Invalid data", ex.Message);
        }

        [Fact]
        public void StringToCount_InvalidNumber_ThrowException()
        {
            const string invalidNumber = "one";

            Exception ex = Assert.Throws<ApplicationException>(() => Services.StringToCount(invalidNumber));

            Assert.Equal("Invalid data", ex.Message);
        }

        [Fact]
        public void StringToCount_ValidNumber_Success()
        {
            const string validNumber = "2";

            var actual = Services.StringToCount(validNumber);

            Assert.Equal(2, actual);
        }
    }
}
