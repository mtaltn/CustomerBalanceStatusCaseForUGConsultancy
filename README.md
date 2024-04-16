# CustomerBalanceStatus
* Proje içerisindeki asıl amaç ödeme ve borç alma işlemlerinin bolunduğu tablolarda aşağıdaki sp ile en yüksek borç miktarına en son hangi tarihte ulaştı onu bulmaktır.

ALTER PROCEDURE [dbo].[FindMaxDebtDatetemp]
    @MUSTERI_ID INT
AS
BEGIN
    DECLARE @MaxDebtDate DATE;
    DECLARE @MaxDebt DECIMAL(18, 2);

    DECLARE @StartDate DATE;
    DECLARE @EndDate DATE;

    SELECT @StartDate = MIN(FATURA_TARIHI), @EndDate = MAX(ODEME_TARIHI) 
    FROM musteri_fatura_table 
    WHERE MUSTERI_ID = @MUSTERI_ID;

    SET @MaxDebt = 0; -- En yüksek borç miktarını sıfırla

    WHILE @StartDate <= @EndDate
    BEGIN
        DECLARE @TotalDebt DECIMAL(18, 2);
        SET @TotalDebt = (
            SELECT SUM(FATURA_TUTARI)
            FROM musteri_fatura_table
            WHERE MUSTERI_ID = @MUSTERI_ID AND FATURA_TARIHI <= @StartDate
        ) - (
            SELECT SUM(ISNULL(FATURA_TUTARI, 0))
            FROM musteri_fatura_table
            WHERE MUSTERI_ID = @MUSTERI_ID AND ODEME_TARIHI <= @StartDate
        );

        IF @TotalDebt > @MaxDebt
        BEGIN
            SET @MaxDebt = @TotalDebt;
            SET @MaxDebtDate = @StartDate;
        END;

        SET @StartDate = DATEADD(DAY, 1, @StartDate);
    END;

    SELECT @MaxDebtDate AS MaxDebtDate, @MaxDebt AS MaxDebt;
END;
