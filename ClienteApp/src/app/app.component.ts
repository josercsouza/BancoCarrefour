import { Component, OnInit, ViewChild } from '@angular/core';

import { PoMenuComponent, PoMenuItem } from '@po-ui/ng-components';

import { environment } from 'src/environments/environment';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    @ViewChild('mainMenu') menu!: PoMenuComponent;

    appTitle = environment.productName;
    menuItems: Array<PoMenuItem> = [];

    constructor() {}

    ngOnInit(): void {
        this.setupComponents();
    }

    private setupComponents() {
        this.menuItems = [
            {
                label: 'Lancamentos',
                shortLabel: 'Lanc',
                icon: 'po-icon-finance',
                link: '/lancamentos',
                action: () => this.menu.collapse()
            }
        ];
    }
}
