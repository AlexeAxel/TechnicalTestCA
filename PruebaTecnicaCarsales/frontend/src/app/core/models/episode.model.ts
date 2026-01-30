export interface Episode {
  id: number;
  name: string;
  airDate: string;
  episodeCode: string;
  characters: string[];
  url: string;
  created: string;
}

export interface PageInfo {
  count: number;
  pages: number;
  next: string | null;
  prev: string | null;
  currentPage: number;
}

export interface PagedEpisodeResponse {
  pageInfo: PageInfo;
  episodes: Episode[];
}
