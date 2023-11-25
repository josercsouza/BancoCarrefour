import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';

import { IRelatorioSaldo } from './../interfaces/relatorio-saldo.interface';
import { LancamentoDia } from './../models/lancamento-dia.model';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class CarrefourService {
    constructor(private http: HttpClient) {}

    getSaldo(dataInicial: string, dataFinal: string): Observable<Array<LancamentoDia>> {
        let url = `${environment.apiEndPointCarrefour}/Relatorio/saldo?dataInicial=${dataInicial}&dataFinal=${dataFinal}&sintetico=false`;

        return this.http.get<IRelatorioSaldo>(url).pipe(
            map(response => {
                let lancamentoDia = Array<LancamentoDia>(0);

                if (response.itens.length > 0) {
                    let saldoAnterior = response.itens[0].saldoAnterior;

                    response.itens.forEach(item => {
                        item.valores.forEach(item2 => {
                            let lanca = new LancamentoDia({ data: item.data, saldoAnterior: saldoAnterior, valor: item2.valor });
                            lancamentoDia.push(lanca);
                            saldoAnterior = lanca.saldoAtual;
                        });
                    });
                }

                return lancamentoDia;
            })
        );
    }

    postNovoLancamento(body: any): Observable<any> {
        let url = `${environment.apiEndPointCarrefour}/Lancamento`;

        return this.http.post<any>(url, body).pipe(take(1));
    }
}
