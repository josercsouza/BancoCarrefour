export interface IRelatorioSaldo {
    itens: Array<IRelSaldoDia>;
}

export interface IRelSaldoDia {
    data: string;
    saldoAnterior: number;
    valores: Array<IRelLancamento>;
}

export interface IRelLancamento {
    dataEfetiva: string;
    valor: number;
}
