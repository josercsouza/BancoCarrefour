import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';

import { PoModalAction, PoModalComponent, PoNotificationService } from '@po-ui/ng-components';

import { CarrefourService } from 'src/app/shared/services/carrefour.service';
import { dateToISOString } from 'src/app/shared/util/date-to-iso-string';

@Component({
    selector: 'app-novo-lancamento',
    templateUrl: './novo-lancamento.component.html',
    styleUrls: ['./novo-lancamento.component.css']
})
export class NovoLancamentoComponent implements OnInit {
    @ViewChild(PoModalComponent, { static: true }) poModal!: PoModalComponent;
    @Output() search: EventEmitter<any> = new EventEmitter<any>();

    dataEfetiva: string = dateToISOString(new Date());
    valor: number = 0;

    primaryAction!: PoModalAction;
    secondaryAction!: PoModalAction;

    isProcessing: number = 0;

    constructor(private poNotificationService: PoNotificationService, private carrefourService: CarrefourService) {}

    ngOnInit(): void {
        this.setupComponents();
    }

    setupComponents(): void {
        this.primaryAction = {
            label: 'Processar',
            action: () => this.apply()
        };
        this.secondaryAction = {
            label: 'Cancelar',
            action: () => this.back()
        };
    }

    open(): void {
        this.dataEfetiva = dateToISOString(new Date());
        this.valor = 0;

        this.poModal.open();
    }

    back(): void {
        this.poModal.close();
    }

    apply(): void {
        this.isProcessing++;
        this.carrefourService
            .postNovoLancamento({
                dataEfetiva: this.dataEfetiva,
                valor: this.valor
            })
            .subscribe({
                next: (response: any) => {
                    this.isProcessing--;

                    if (response && response.sucesso) {
                        this.search.emit();
                        this.poModal.close();
                        // } else {
                        //     this.poNotificationService.error('Algum problema nos dados !!!');
                    }
                },
                error: () => {
                    this.isProcessing--;
                    this.poNotificationService.error('Algum problema nos dados !!! Data futura ou valor zerado.');
                }
            });
    }
}
