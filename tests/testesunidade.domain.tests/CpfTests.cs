using Xunit;

namespace testesunidade.domain.tests;

public class CpfTests
{
    [Fact(DisplayName = "CPF informado deve estar válido")]
    public void CPF_validar_cpf_deve_ter_sucesso()
    {
        //Arrange
        var cpf = new Cpf("089.724.820-13");

        //Act
        var valido = cpf.EstaValido();


        //Assert
        Assert.True(valido);
    }

    [Theory(DisplayName = "Validar CPF em massa de ter sucesso")]
    [InlineData("089.724.820-13", true)]
    [InlineData("089.724.820-15", false)]
    [InlineData("999.999.999-99", false)]
    public void CPF_validar_cpf_massa_deve_ter_sucesso(string cpfInformado, bool retorno)
    {
        //Arrange
        var cpf = new Cpf(cpfInformado);

        //Act
        var resultado = cpf.EstaValido();

        //Assert
        Assert.True(resultado == retorno);
    }

}
