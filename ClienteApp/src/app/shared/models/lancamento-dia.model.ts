import { ILancamentoDia } from '../interfaces/lancamento-dia.interface';

export class LancamentoDia implements ILancamentoDia {
    data: string = '';
    saldoAnterior: number = 0;
    valor: number = 0;

    get saldoAtual(): number {
        return this.saldoAnterior + this.valor;
    }

    constructor(value?: ILancamentoDia) {
        if (value) {
            Object.assign(this, value);
        }
    }
}
