import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { customer } from '../Models/Customer.model';
import { Observable } from 'rxjs';
const API_BASE_URL:string="https://localhost:7228/api/Customer/";
@Injectable({
  providedIn: 'root'
})

export class CustomerService {

  constructor(private httreq:HttpClient) { }
  //baseapiurl:string="https://localhost:7228/api/"


  getAllcustomer():Observable<customer[]>{
     return this.httreq.get<customer[]>(`${API_BASE_URL}GetAllCustomer`);
  }

  addCustomer(addcustomerrequest:customer):Observable<customer>{
      return this.httreq.post<customer>(`${API_BASE_URL}Addcustomer`,addcustomerrequest)

  }
  getcustomerbyId(id:string):Observable<customer>{
    return this.httreq.get<customer>(`${API_BASE_URL}Getcustomer/${id}`)
  }

  updatecustomer(id:string,updaterequest:customer):Observable<customer>{
    return this.httreq.put<customer>(`${API_BASE_URL}Putcustomer/${id}`,updaterequest);
  }

  deletecustomerbyId(id:string):Observable<customer>{
    return this.httreq.delete<customer>(`${API_BASE_URL}deletecustomer/${id}`)
  }
}
