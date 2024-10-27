import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  private apiUrl = 'https://localhost:7032/api/games';

  constructor(private http: HttpClient) { }

  registerPlay(data: any): Observable<any> {
    return this.http.post(this.apiUrl, data);
  }

}
