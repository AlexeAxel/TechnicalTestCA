import { Injectable, inject, signal } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { PagedEpisodeResponse, Episode } from '../models/episode.model';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EpisodeService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.apiUrl}/episodes`;

  episodes = signal<Episode[]>([]);
  loading = signal<boolean>(false);
  error = signal<string | null>(null);

  getEpisodes(page: number = 1, name?: string, episode?: string): Observable<PagedEpisodeResponse> {
    this.loading.set(true);
    this.error.set(null);

    let params = new HttpParams().set('page', page.toString());

    if (name) {
      params = params.set('name', name);
    }

    if (episode) {
      params = params.set('episode', episode);
    }

    return this.http.get<PagedEpisodeResponse>(this.baseUrl, { params }).pipe(
      tap({
        next: (response) => {
          this.episodes.set(response.episodes);
          this.loading.set(false);
        },
        error: (error) => {
          this.error.set('Error al cargar los episodios');
          this.loading.set(false);
        }
      })
    );
  }

  getEpisodeById(id: number): Observable<Episode> {
    this.loading.set(true);
    this.error.set(null);

    return this.http.get<Episode>(`${this.baseUrl}/${id}`).pipe(
      tap({
        next: () => this.loading.set(false),
        error: () => {
          this.error.set('Error al cargar el episodio');
          this.loading.set(false);
        }
      })
    );
  }
}
