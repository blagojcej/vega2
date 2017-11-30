import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';

@Injectable()
export class MakeService {

  private readonly _url : string ='http://localhost:5000';
  headers;

  constructor(private http: Http) { 
    this.headers = new Headers({'Content-Type': 'application/json'}, )
  }

  getMakes(){
    return this.http.get(this._url+'/makes/getmakes', {headers: this.headers})
    .map(res=>res.json());
  }
}
