import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

export class Config {

};

@Injectable({
  providedIn: 'root'
})
export class MonedaService {
    configUrl = 'api/cryptomonedas';

    getListaMonedas( key ) {
        return this.http.get<string>(this.configUrl + '/' + key );
    }

    constructor(private http: HttpClient) {

    }
}
