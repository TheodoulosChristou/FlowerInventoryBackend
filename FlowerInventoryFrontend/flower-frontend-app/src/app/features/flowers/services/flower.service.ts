import { Injectable } from '@angular/core';
import { Flower } from '../../../../models/flower.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { BaseCommandResponse } from '../../../../models/baseCommandResponse.model';
import { Category } from '../../../../models/category.model';

@Injectable({
  providedIn: 'root'
})
export class FlowerService {

  constructor(private http:HttpClient) { }

  addFlower(model:Flower):Observable<Flower> {
    return this.http.post<Flower>('https://localhost:7163/api/Flower/CreateFlower',model);
  }

  updateFlower(model:Flower):Observable<Flower> {
    return this.http.put<Flower>('https://localhost:7163/api/Flower/UpdateFlower',model);
  }

  getFlowers(): Observable<Flower[]> {
    return this.http.get<Flower[]>('https://localhost:7163/api/Flower/GetAllFlowers');
  }

  deleteFlower(model: Flower): Observable<BaseCommandResponse> {
    return this.http.request<BaseCommandResponse>('delete', 'https://localhost:7163/api/Flower/DeleteFlower', {
      body: model
    });
  }

  getAllCategories():Observable<Category[]>{
    return this.http.get<Category[]>('https://localhost:7163/api/Category/GetAllCategories');
  }
}
