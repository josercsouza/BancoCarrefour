import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { PoModule } from '@po-ui/ng-components';
import { PoTemplatesModule } from '@po-ui/ng-templates';

import { AppComponent } from './app.component';
import { LancamentosComponent } from './core/lancamentos/lancamentos.component';
import { NovoLancamentoComponent } from './core/lancamentos/novo-lancamento/novo-lancamento.component';

@NgModule({
    declarations: [AppComponent, LancamentosComponent, NovoLancamentoComponent],
    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: 'lancamentos', component: LancamentosComponent },
            { path: '**', redirectTo: 'lancamentos' }
        ]),
        PoModule,
        PoTemplatesModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule {}
