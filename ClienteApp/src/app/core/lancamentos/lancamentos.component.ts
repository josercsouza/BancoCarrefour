import { Component, OnInit, ViewChild } from '@angular/core';

import { Subscription } from 'rxjs';
import { PoPageAction, PoTableColumn } from '@po-ui/ng-components';

import { ILancamentoDia } from 'src/app/shared/interfaces/lancamento-dia.interface';
import { CarrefourService } from './../../shared/services/carrefour.service';
import { dateToISOString } from 'src/app/shared/util/date-to-iso-string';

import { NovoLancamentoComponent } from './novo-lancamento/novo-lancamento.component';

@Component({
    selector: 'app-lancamentos',
    templateUrl: './lancamentos.component.html',
    styleUrls: ['./lancamentos.component.css']
})
export class LancamentosComponent implements OnInit {
    @ViewChild(NovoLancamentoComponent, { static: true }) novoLancamentoModal!: NovoLancamentoComponent;

    initial_date: string = dateToISOString(new Date());
    final_date: string = dateToISOString(new Date());

    isLoading = false;
    pageActions: Array<PoPageAction> = [];
    columns: Array<PoTableColumn> = [];
    items: Array<ILancamentoDia> = [];

    subscriptions: Subscription = new Subscription();

    constructor(private carrefourService: CarrefourService) {}

    ngOnInit(): void {
        this.setupComponents();
    }

    private setupComponents(): void {
        this.pageActions = [{ label: 'Novo', action: () => this.new() }];

        this.columns = [
            {
                property: 'data',
                label: 'Data',
                type: 'date'
            },
            {
                property: 'saldoAnterior',
                label: 'Saldo Anterior',
                type: 'number',
                format: '1.2-2'
            },
            {
                property: 'valor',
                label: 'Lancamento',
                type: 'number',
                format: '1.2-2'
            },
            {
                property: 'saldoAtual',
                label: 'Saldo Atual',
                type: 'number',
                format: '1.2-2'
            }
        ];
    }

    search(): void {
        this.isLoading = true;
        this.unsubscribe();
        this.subscriptions.add(
            this.carrefourService.getSaldo(this.initial_date, this.final_date).subscribe({
                next: (response: Array<ILancamentoDia>) => {
                    this.items = [...response];

                    this.isLoading = false;
                },
                error: () => {
                    this.isLoading = false;
                }
            })
        );
    }

    private unsubscribe() {
        this.subscriptions.unsubscribe();
        this.subscriptions = new Subscription();
    }

    new(): void {
        this.novoLancamentoModal.open();
    }
}
