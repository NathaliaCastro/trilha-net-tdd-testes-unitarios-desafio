using System.Globalization;
using Calculadora.Services;

namespace CalculadoraTestes;

public class CalculadoraTests
{
    private FuncaoCalculadora _calc;
    public CalculadoraTests()
    {
        _calc = new FuncaoCalculadora();
    }

    [Fact]
    public void SomarDoisValores()
    {
        // Arrange
        int num1 = 10;
        int num2 = 20;

        // Act
        int resultado = _calc.Somar(num1, num2);

        // Assert
        Assert.Equal(30, resultado);
    }

    // Realiza mais de uma verificação para o método Somar - boas práticas
    [Theory]
    [InlineData (30, 40, 70)]
    [InlineData (50, 60, 110)]
    [InlineData (70, 80, 150)]
    public void SomandoDoisValoresDiferentes3Vezes(int num1, int num2, int resultado)
        // Os primeiros valores (30, 50, 70) serão atribuidos em NUM1
        // Os segundos valores (40, 60, 80) serão atribuidos em NUM2
        // Os últimos valores (70, 110, 150) serão atribuidos em RESULTADO
    {

        // Act
        int resultadoTeoria = _calc.Somar(num1, num2);

        // Assert
        Assert.Equal(resultado, resultadoTeoria);
    }

    [Fact]
    public void SubtrairDoisValores()
    {
        // Arrange
        int num1 = 30;
        int num2 = 20;

        // Act
        int resultado = _calc.Subtrair(num1, num2);

        // Assert
        Assert.Equal(10, resultado);
    }

    [Fact]
    public void MultiplicarDoisValores()
    {
        // Arrange
        int num1 = 8;
        int num2 = 5;

        // Act
        int resultado = _calc.Multiplicar(num1, num2);

        // Assert
        Assert.Equal(40, resultado);
    }

    [Fact]
    public void DividirDoisValores()
    {
        // Arrange
        int num1 = 125;
        int num2 = 5;

        // Act
        int resultado = _calc.Dividir(num1, num2);

        // Assert
        Assert.Equal(25, resultado);
    }

    [Fact]
    public void DividirPorZero()
    {
        // Assert - criando uma exceção
        Assert.Throws<DivideByZeroException>(() => _calc.Dividir(10, 0));
            //Dividindo 10 por 0 , será retornado exceção pois não há divisão por ZERO
    }

    [Fact]
    public void PotenciacaoDeDoisValores()
    {
        // Arrange
        int num1 = 3;
        int num2 = 3;

        // Act
        double pot = Math.Pow(num1, num2);
        int resultado = _calc.Potencia(num1, num2);

        // Assert
        Assert.Equal(27, resultado);
    }

    [Fact]
    public void HistoricoCalculadora()
    {
        // Arrange
        _calc.Somar(10, 20);        //posição 0
        _calc.Subtrair(30, 20);     //posição 1
        _calc.Multiplicar(8, 5);    //posição 2
        _calc.Dividir(125, 5);      //posição 3
        _calc.Somar(70, 80);        //posição 4
        _calc.Multiplicar(9, 8);    //posição 5
        _calc.Subtrair(20, 40);     //posição 6
        _calc.Potencia(8, 3);       //posição 7

        // Act
        var lista = _calc.historico();

        // Assert
        Assert.NotEmpty(lista);
        Assert.Equal(3, lista.Count);

            // A lista possui 8 elementos e quero armazenar apenas os 3 mais recentes. 
            // Então, cinco elementos serão removidos (posição 0 até 4)
            // Retornará os seguintes resultados: 72, -20 e 512 (posição 5 até 7)
    }
            
            // Observaão final: quando utilizamos o FACT, o código é executado por bloco. Quando utilizamos o THEORY, é executado por linhas
                // Ao todos são 7 FACTs e 3 linhas em Theory = 10 validações
}
