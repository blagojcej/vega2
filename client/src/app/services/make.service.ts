import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';

@Injectable()
export class MakeService {

  private readonly _url : string ='http://localhost:5000';

  constructor(private http: Http) { }

  getMakes(){
    return this.http.get(this._url+'/makes/getmakes')
    .map(res=>res.json());
  }
}
