import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from './models/user.model';

@Injectable({ providedIn: 'root' })
export class AuthService {
  currentUserId: number | null = null;

  constructor(private http: HttpClient) {}

  loginFromLocalStorage() {
    const id = window.localStorage.getItem('userId');
    if (id && +id > 0) {
      this.currentUserId = +id;
    }
  }

  login(email: string, password: string): Observable<number> {
    return this.http.post<number>('https://localhost:7176/api/auth/login', {
      email,
      password,
    });
  }

  logout() {
    this.currentUserId = null;
    window.localStorage.setItem('userId', '');
  }

  createNewUser(user: User) {
    return this.http.post('https://localhost:7176/api/auth/register', user);
  }
}
