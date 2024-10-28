import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GameStartRequest } from '../models/game-start-request.model';

@Injectable({
  providedIn: 'root',
})
export class GameService {
  private apiUrl = 'https://gameofdrones-d9h6c8ducmbbhrec.canadacentral-01.azurewebsites.net/api/game'; 


  constructor(private http: HttpClient) {}

  startGame(request: GameStartRequest): Observable<any> {
    return this.http.post(`${this.apiUrl}/start`, request);
  }
}
