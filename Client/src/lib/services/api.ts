async function get(
  route: string,
  fetch: (input: RequestInfo | URL, init?: RequestInit | undefined) => Promise<Response>
) {
  try {
    const response = await fetch(`http://localhost:4001/${route}`, {
      headers: {
        Origin: 'http://localhost:5173'
      }
    });
    return await response.json();
  } catch (e) {
    console.log(e);
    return [];
  }
}

async function post(
  route: string,
  body: BodyInit,
  params: string,
  fetch: (input: RequestInfo | URL, init?: RequestInit | undefined) => Promise<Response>
) {
  try {
    const response = await fetch(`http://localhost:4001/${route}${params}`, {
      method: 'POST',
      body: body,
      headers: {
        Origin: 'http://localhost:5173'
      }
    });
    return await response.json();
  } catch (e) {
    console.log(e);
    return [];
  }
}

export const api = {
  get,
  post
};
