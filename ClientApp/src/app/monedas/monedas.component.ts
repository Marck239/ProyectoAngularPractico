import { Component, OnInit } from '@angular/core';
import { MonedaService } from '../moneda.service'

@Component({
  selector: 'app-monedas',
  templateUrl: './monedas.component.html',
  styleUrls: ['./monedas.component.css']
})
export class MonedasComponent implements OnInit {
    key = 'c938d852-6940-4082-8b77-517c72f1805c';
    monedas = [];
    valor = 1;
    monedaOrigen = 0;
    error = '';
    constructor(private monedaServ: MonedaService) { }

    ngOnInit() {
        this.fetchMonedas();
        setInterval(() => {
            this.fetchMonedas();
        }, 5000);
    }

    fetchMonedas() {
        if (this.key == '') {
            this.error = 'Api key no puede estar vacio';
            return;
        }
        this.monedaServ.getListaMonedas(this.key).subscribe((data: any) => {
            if (data.data != undefined) {
                this.monedas = data.data;
                this.error = '';
            }
            else {
                this.error = 'Api key incorrecto';
            }
        } );
    }

}
