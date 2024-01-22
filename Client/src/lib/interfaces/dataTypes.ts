export interface Championship {
  id: number,
  name: string,
  logoUrl: string,
  region: string
};

export interface Player {
  id: number,
  name: string,
  photoUrl: string
};

export interface Team {
  id: number,
  name: string,
  logoUrl: string,
  acronym: string
};