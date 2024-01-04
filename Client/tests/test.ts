import { expect, test } from '@playwright/test';

test.use({
  viewport: { width: 360, height: 740 }
});

test('home page displays header', async ({ page }) => {
  await page.goto('/');
  await expect(page.getByRole('banner')).toBeVisible();
});

test('home page displays prediction container', async ({ page }) => {
  await page.goto('/');
  await expect(page.getByTestId('predictions')).toBeVisible();
});

test.describe('on desktop', () => {
  test.use({ viewport: { width: 1920, height: 1080 } });

  test('home page displays upcoming matches and favorites container', async ({ page }) => {
    await page.goto('/');
    await expect(page.getByTestId('upcoming-favorites')).toBeVisible();
  });
});
